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
        
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
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








    }
    
}
