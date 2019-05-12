using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 3;
    public float invulnerableTimer = 0;
    private int correctLayer;

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIG");

        
        health--;
        invulnerableTimer = 2f;
        gameObject.layer = 10;
        
    }



    void Update()
    {
        invulnerableTimer -= Time.deltaTime;

        if (invulnerableTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }

        if (health <= 0)
        {
            Remove();
        }
    }



    void Remove()
    {
        Destroy(gameObject);
    }
}
