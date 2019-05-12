using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 3;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIG");
        health--;
        
    }



    void Update()
    {
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
