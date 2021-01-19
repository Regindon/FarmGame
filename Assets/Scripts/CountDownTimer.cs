using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text timerText;
    public static float CountdownTime = 90;
    
    

    void Start()
    {
        StartCoundownTimer();
        CountdownTime = PlayerPrefs.GetFloat("CountdownTime", CountdownTime);
    }

    void StartCoundownTimer()
    {
         if (timerText != null)
         {
             CountdownTime = 90;
             timerText.text = "Time Left: 01:30";
             InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
             
         }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            CountdownTime -= Time.deltaTime;
            string minutes = Mathf.Floor(CountdownTime / 60).ToString("00");
            string seconds = (CountdownTime % 60).ToString("00");
            timerText.text = "Time Left: " + minutes + ":" + seconds;
            PlayerPrefs.SetFloat("CountdownTime", CountdownTime);
            if (Input.GetKeyDown(KeyCode.P))
            {
                CountdownTime = 90;
            }
        }
    }

    private void Update()
    {
        
        if (CountdownTime <= 0 && PlayerMovement.repair == 0)
        {
            FinishGame();
        }
        else if (CountdownTime <=0 && PlayerMovement.repair != 0)
        {
            GameOver();
        }
    }
    
    private void GameOver()
    {
        SceneManager.LoadScene(2); 
    }

    private void FinishGame()
    {
        SceneManager.LoadScene(3); 
    }
}
