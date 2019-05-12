// TIMED CLEANUP component (C#)

// UNITY Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SCRIPT - FOR: Gameobject that needs to be destroyed after 
 * an amount of time. THis is dsigned to not use up memory with
 * created prefabs... i.e. ...BULLETS
 */ 

// INT. Class
public class BulletTimedDestroy : MonoBehaviour
{
    // Time amount value
    public float timer = 5;



    // UPDATE METHOD - updates each frame
    void Update()
    {
        // REWORDED: Time alotted value -1 seconds... not by frame, by time.
        timer -= Time.deltaTime;

        // STATMENT to TRIGGER gameobject(BULLET) to be destroyed after time runs out.

        // If time alotted is less or equal to 0.
        if(timer <= 0)
        {
            // Destroy gameobject this is attached to in UNITY
            Destroy(gameObject);
        }
    }// --- END update method
}// --- END CLASS
