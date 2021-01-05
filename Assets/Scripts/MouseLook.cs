﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSens = 1000f;
    public Transform playerBody;
    private float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* mouseSens * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -20f, 25f);
        transform.localRotation=Quaternion.Euler(xRotation, 0f,0f);
        playerBody.Rotate(Vector3.up*mouseX);
    }
}
