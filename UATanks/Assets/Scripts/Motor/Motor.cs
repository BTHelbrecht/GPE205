// MOTOR component (C#)

// UNITY Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * SCRIPT - FOR: 2D TANK, TOP DOWN
 * 
 * DESCRIPTION: 
 * This is the moving mechanism for a 2D TOP DOWN view game for and object.
 * It utilizes THE "WASD" Keys on a key board, allowing speeds to be ajusted
 * and calls methods from inside the class. This must be attached to the 
 * GAMEOBJECT you want to have utilize it. 
 */

// INT. CLASS
public class Motor : MonoBehaviour
{
    // Forarward speed value
    public float speedForward = 1;
    // Reverse speed value
    public float speedReverse = 0.5f;
    // Left rotating speed value
    public float counterClockWise = 30;
    // Right rotating speed value
    public float clockWise = -30;
    // Unity rigidbody value... ASSIGN in UNITY
    public Rigidbody2D body;



    // START METHOD - starts at INT.
    void Start()
    {
        // Body Variable... GETS rigidbody from INSPECTOR
        body = GetComponent<Rigidbody2D>();
    }// --- END start method

    
    // UPDATE METHOD - updates each frame
    void Update()
    {
        // MOVE METHOD call
        Move();
    }// --- END update method


    // MOVE METHOD - only on call
    private void Move()
    {
        // STAMENTS for "WASD" keys when pressed. 

        // If -w- is pressed... call FORWARD METHOD
        if (Input.GetButton("w"))
        {
            // FORWARD METHOD call
            Forward();
        }
        // If -s- is pressed... call REVERSE METHOD
        if (Input.GetButton("s"))
        {
            // REVERSE METHOD call
            Reverse();
        }
        // If -a- is pressed... call ROTATELEFT METHOD
        if (Input.GetButton("a"))
        {
            // ROTATELEFT METHOD call
            RotateLeft();
        }
        // If -d- is pressed... call ROTATERIGHT METHOD
        if (Input.GetButton("d"))
        {
            // ROTATERIGHT METHOD call
            RotateRight();
        }
    }// --- END move method


    // FORWARD METHOD - only on call
    private void Forward()
    {
        // Moves the GAMEOBJECT RIGIDBODY2D forward

        // DEBUG for test in UNITY log
        Debug.Log("f");
        // REWORDED: change.position((x,y).up * 1 * Time based.. Not Frame Based)
        transform.Translate(Vector2.up * speedForward * Time.deltaTime);
    }// --- END forward method

    private void Reverse()
    {
        // Moves the GAMEOBJECT RIGIDBODY2D reverse

        // DEBUG for test in UNITY log
        Debug.Log("r");
        // REWORDED: change.position((x,y).down * .5 * Time based.. Not Frame Based)
        transform.Translate(Vector2.down * speedReverse * Time.deltaTime);
    }// --- END reveres method

    private void RotateLeft()
    {
        // Moves the GAMEOBJECT RIGIDBODY2D turn left

        // DEBUG for test in UNITY log
        Debug.Log("RL");
        // change.turn(make(x,y,z) ON Y AXIS---(null, null, axis of -a- * -30deg. * Time based.. Not Frame Based))
        transform.Rotate(new Vector3(0, 0, Input.GetAxis("a") * counterClockWise * Time.deltaTime));
    }// --- END rotateleft method

    private void RotateRight()
    {
        // Moves the GAMEOBJECT RIGIDBODY2D turn right

        // DEBUG for test in UNITY log
        Debug.Log("RR");
        // change.turn(make(x,y,z) ON Y AXIS---(null, null, axis of -a- * 30deg. * Time based.. Not Frame Based))
        transform.Rotate(new Vector3(0, 0, Input.GetAxis("d") * clockWise * Time.deltaTime));
    }// --- END rotateright method
}

