using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject turret;
    // Update is called once per frame
    void Update()
    {
        TurretRotation();
    }

    void TurretRotation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - turret.transform.position.x, mousePosition.y - turret.transform.position.y);

        turret.transform.up = direction;
    }
}
