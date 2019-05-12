using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringMechanism : MonoBehaviour
{
    public float fireRate = 3;
    float timeUntilFire = 0;

    public Transform firePoint;
    public GameObject bullet;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Space") && Time.time > timeUntilFire)
        {
            RateOfFire();
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void RateOfFire()
    {
        timeUntilFire = Time.time + 1 / fireRate;
    }
}
