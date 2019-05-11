using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speedForward = 1;
    public float speedReverse = 0.5f;
    public float counterClockWise = 30;
    public float clockWise = -30;

    public Rigidbody2D body;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetButton("w"))
        {
            Forward();
        }
        if (Input.GetButton("s"))
        {
            Reverse();
        }
        if (Input.GetButton("a"))
        {
            RotateLeft();
        }
        if (Input.GetButton("d"))
        {
            RotateRight();
        }
    }

    private void Forward()
    {
        //move forward
        Debug.Log("f");
        transform.Translate(Vector2.up * speedForward * Time.deltaTime);
    }

    private void Reverse()
    {
        //move reverse
        Debug.Log("r");
        transform.Translate(Vector2.down * speedReverse * Time.deltaTime);
    }

    private void RotateLeft()
    {
        //rotate left
        Debug.Log("RL");
        transform.Rotate(new Vector3(0, 0, Input.GetAxis("a") * counterClockWise * Time.deltaTime));
    }

    private void RotateRight()
    {
        //rotate right
        Debug.Log("RR");
        transform.Rotate(new Vector3(0, 0, Input.GetAxis("d") * clockWise * Time.deltaTime));
    }
}

