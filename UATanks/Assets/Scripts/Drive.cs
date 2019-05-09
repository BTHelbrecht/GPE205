// Drive 

// This is the drive mechanic for the player tank

// Unity Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class... Drive
public class Drive : MonoBehaviour
{
    // Variables... tank movespeed, and turret move speed.
    public float moveSpeed = 1;
    public float rotationSpeed = 12;

    void FixedUpdate()
    {
        //This is the location of tank 
        float moveVector = Input.GetAxis("Vertical");
        float rotateVector = Input.GetAxis("Horizontal");

        // Mechanic... This is the equation. Location x move speed x time rate.
        this.transform.Translate(0f, moveVector * moveSpeed * Time.deltaTime, 0f);
        this.transform.Rotate(0f, 0f, -rotateVector * (rotationSpeed* 10) * Time.deltaTime);
    }
}
