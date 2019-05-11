using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public float speedForward;

    public Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void MoveForward()
    {
        Debug.Log("Forawrd");
        Vector2 forward = new Vector2(0, Input.GetAxis("w"));
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position * (speedForward * Time.fixedDeltaTime));
    }
}
