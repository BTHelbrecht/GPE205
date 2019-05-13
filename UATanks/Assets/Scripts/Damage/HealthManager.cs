// HEALTH component (C#)

// UNITY Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SCRIPT - FOR: TRACK LIFE OF THIS PROGRAM ONLY
 * 
 * DESCRIPTION:
 * This take care of the health for all the units in the game. I want
 * split this up in the end run. I also Want to make this more effiecient.
 * I also have the text routed to the canvas for the display of points.
 */ 

// INT. CLASS
public class HealthManager : MonoBehaviour
{
    // Health value
    public int health = 5;
    // Damage from bullet value
    public int bulletDamage = 2;
    // Damage from crashing value
    public int ramDamage = 1;
    // Hit score value
    public int score = 0;
    


    // COLLIDER METHOD - only on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // STAMENTS FOR CONDITIONS

        // if collider hit a enemy
        if(collision.gameObject.tag == "Enemy")
        {
            // decreas health by ram damage
            health -= ramDamage;
            Debug.Log("enemy");
            
        }
        // if collider hit a player
        if (collision.gameObject.tag == "Player")
        {
            // decrease health by ram damage
            health -= ramDamage;
            Debug.Log("player");
        }
        // if collider hit a bullet
        if (collision.gameObject.tag == "Bullet")
        {
            // decrease health by bullet damage
            health -= bulletDamage;
            Debug.Log("bullet");
        }

        // add 1 to score value
        score++;
        // Send score value to text canvas
        ScoreDisplay.scoreValue = score;
    }// END --- collision method


    // UPDATE METHOD - updates each frame
    void Update()
    {
        // STATEMENTS

        // if health is less or equal to 0
        if (health <= 0)
        {
            // REMOVE method call
            Remove();
        }
    }// END --- update method
    

    // REMOVE METHOD - only on call
    void Remove()
    {
        // Destroy game object attached to.
        Destroy(gameObject);
    }// END --- remove method
}// END --- CLASS
