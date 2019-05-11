using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speedForward;
    public float speedReverse;

    public Rigidbody2D body;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetButton("w"))
        {
            //move forward
            Debug.Log("f");
            transform.Translate(Vector2.up * speedForward * Time.deltaTime);
        }
        if (Input.GetButton("s"))
        {
            //move reverse
            Debug.Log("r");
            transform.Translate(Vector2.down * speedReverse * Time.deltaTime);
        }
        if (Input.GetButton("a"))
        {
            //rotate left
            Debug.Log("RL");

        }
        if (Input.GetButton("d"))
        {
            //rotate right
            Debug.Log("RR");

        }
    }
}

