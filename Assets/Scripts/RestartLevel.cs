using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(0);
            
        }
        PlayerPrefs.SetFloat("CountdownTime", CountDownTimer.CountdownTime);
        if (Input.GetKeyDown(KeyCode.P))
        {
            CountDownTimer.CountdownTime = 180;
        }
    }
}
