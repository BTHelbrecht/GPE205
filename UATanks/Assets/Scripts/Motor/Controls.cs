using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D body;

    [SerializeField] private Forward forward;
    [SerializeField] private Reverse reverse;
    [SerializeField] private Rotate rotate;
   
    
     void Start()
    {
        body = GetComponent<Rigidbody2D>();
        forward = GameObject.FindGameObjectWithTag("Motor").GetComponent<Forward>();
        reverse = GameObject.FindGameObjectWithTag("Motor").GetComponent<Reverse>();
        rotate = GameObject.FindGameObjectWithTag("Motor").GetComponent<Rotate>();
    }

    void Update()
    {
        if (Input.GetButton("w"))
        {
            //move forward
            Debug.Log("f");
            forward.MoveForward();

        }
        if (Input.GetButton("s"))
        {
            //move reverse
            Debug.Log("r");
            reverse.MoveReverse();
        }
        if (Input.GetButton("a"))
        {
            //rotate left
            Debug.Log("RL");
            rotate.MoveRotate();
        }
        if (Input.GetButton("d"))
        {
            //rotate right
            Debug.Log("RR");
            rotate.MoveRotate();
        }
    }
}
