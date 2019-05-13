using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 5;
    public int bulletDamage = 2;
    public int ramDamage = 1;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health -= ramDamage;
            Debug.Log("enemy");
        }

        if (collision.gameObject.tag == "Player")
        {
            health -= ramDamage;
            Debug.Log("player");
        }

        if (collision.gameObject.tag == "Bullet")
        {
            health -= bulletDamage;
            Debug.Log("bullet");
        }
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
