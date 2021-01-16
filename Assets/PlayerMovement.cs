using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    //public GameObject rappleText;
    public Transform groundCheck;
    public float groundDisctance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    private bool playerInBarn = false;
    private bool playerInHorse = false;
    private float milk = 0;
    private float horseRent = 0;
    private float sheepWool = 0;
    
        
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
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //get milk
                    milk += 1;

                }
            }

            if (hit.collider.tag == "Horse" && playerInHorse == true && horseRent<3)
            {
                //check if player rent a horse before
                //activate text
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //rent horse
                    horseRent += 1;
                }
            }

            if (hit.collider.tag=="Sheep" && playerInBarn==true && sheepWool <1)
            {
                //check if player sheared wool before
                //activate text
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //shear sheep
                    sheepWool += 1;
                }
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("toMarketPlace"))
        {
            //activate text
            if (Input.GetKeyDown(KeyCode.E))
            {
                //load market scene
            }
        }

        if (other.CompareTag("toMainScene"))
        {
            //activate text
            if (Input.GetKeyDown(KeyCode.E))
            {
                //load main scene
            }
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
        }

        if (other.CompareTag("toMainScene"))
        {
            //disable market text
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
