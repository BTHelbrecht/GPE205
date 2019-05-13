// TURRET component (C#)

// UNITY Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SCRIPT - FOR: 2D TOP DOWN OBJET ROTATE TO MOUSE.
 * 
 * DESCRIPTION:
 * This is the component that I use to have the tank turret
 * follow the mouse.
 */

// INT. CLASS
public class Turret : MonoBehaviour
{
    // Gameobject for turret value
    public GameObject turret;



    // UPDATE METHOD - updates each frame
    void Update()
    {
        // TURRETROTATION method call
        TurretRotation();
    }// END --- update method


    // TURRETROTATION METHOD - only on call
    void TurretRotation()
    {
        // REWORDED: (x,y,z) variable = mouse position
        Vector3 mousePosition = Input.mousePosition;
        // REWORDED: Mouse position = POINT ON SCREEN MOUSE IS
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // REWORDED: (x,y) variable = new (x,y) 
        Vector2 direction = new Vector2(mousePosition.x - turret.transform.position.x, mousePosition.y - turret.transform.position.y);
        // REWORDED: Change the forward direction to the new location
        turret.transform.up = direction;
    }// END --- turretrotation method
}// END --- CLASS
