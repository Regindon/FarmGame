using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float gravity = -9.81f;
    private Vector3 move;
    public CharacterController controller;
    public float speed = 12f;
    private Vector3 velocity;
    public Camera cam;
    
    public Transform groundCheck;
    public float groundDisctance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    private bool playerInBarn = false;
    private bool playerInHorse = false;
    private bool toMarket = false;
    private bool toMainScene = false;
    private float milk;
    private float horseRent;
    private float sheepWool;
    private float playerMoney;
    public Text marketText;
    public Text mainSceneText;
    public Text milkText;
    public Text horseRentText;
    public Text woolText;
    public Text canMilkText;
    public Text canRentText;
    public Text canWoolText;
    public Text money;
    
        
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerInBarn +" barn");
        Debug.Log(milk+ " milk");
        Debug.Log(sheepWool + " wool");
        Debug.Log( playerInHorse + " horse area");
        Debug.Log( horseRent + " horse rent");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDisctance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag=="Cow"&& playerInBarn==true && milk < 2 )
            {
                //check if player have more then 1 milk
                //activate text
                canMilkText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //get milk
                    milk += 1;

                }
            }
            else
            {
                canMilkText.enabled = false;
            }

            if (hit.collider.tag == "Horse" && playerInHorse == true && horseRent<3)
            {
                //check if player rent a horse before
                //activate text
                canRentText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //rent horse
                    horseRent += 1;
                }
            }
            else
            {
                canRentText.enabled = false;
            }

            if (hit.collider.tag=="Sheep" && playerInBarn==true && sheepWool <1)
            {
                //check if player sheared wool before
                //activate text
                canWoolText.enabled = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //shear sheep
                    sheepWool += 1;
                }
            }
            else
            {
                canWoolText.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && toMarket==true)
        {
            //load market scene
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.E)&& toMainScene==true)
        {
            SceneManager.LoadScene(0);
        }

        milkText.text = milk.ToString();
        horseRentText.text = horseRent.ToString();
        woolText.text = sheepWool.ToString();
        money.text = (playerMoney.ToString() + "$");




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("toMarketPlace"))
        {
            //activate text
            marketText.enabled = true;
            toMarket = true;

        }

        if (other.CompareTag("toMainScene"))
        {
            //activate text
            mainSceneText.enabled = true;
            toMainScene = true;
        }
        if (other.CompareTag("InBarn"))
        {
            playerInBarn = true;
        }
        if (other.CompareTag("InHorseArea"))
        {
            playerInHorse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("toMarketPlace"))
        {
            //disable mainscene text
            marketText.enabled = false;
            toMarket = false;
        }

        if (other.CompareTag("toMainScene"))
        {
            //disable market text
            mainSceneText.enabled = false;
            toMainScene = false;
        }

        if (other.CompareTag("InBarn"))
        {
            playerInBarn = false;
        }

        if (other.CompareTag("InHorseArea"))
        {
            playerInHorse = false;
        }
    }
}
