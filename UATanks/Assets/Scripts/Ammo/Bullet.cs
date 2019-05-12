// BULLET component (C#)

// UNITY Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SCRIPT - FOR: 2D, Anything needing to move forward at a rotation.
 * 
 * DESCRIPTION:
 * THis is to make the bullet move forward in the direction facing
 * the moment is it fired. This also allows the designer to change the
 * BULLETs speed.
 */

// INT. Class
public class Bullet : MonoBehaviour
{
    // Bullet speed value
    public float bulletSpeed = 4;



    // UPDATE METHOD - updates each frame
    void Update()
    {
        /*
         * THis is basicall taking the Y AXIS and rotating it. Then
         * adding to the BULLETs current loaction to make it move
         * forwar in the direction it is facing.
         */

        // REWORDED: (x,y,z) variable = change.position
        Vector3 positon = transform.position;
        // REWORDED: (x,y,z) variable = make(x,y,z) ON Y AXIS---(4 * Time based.. Not Frame Based)
        Vector3 moveBullet = new Vector3(0, bulletSpeed * Time.deltaTime, 0);
        // REWORDED: bullet position +1 change.rotate * bullets speed
        positon += transform.rotation * moveBullet;
        // REWORDED: change.position = bullets position
        transform.position = positon;
    }// --- END update method
}// --- END CLASS
