using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// START CLASS
public class FiringMechanism : MonoBehaviour
{
    // Fire rate value
    public float fireRate = 3;
    // Firepoint starting value
    public Transform firePoint;
    // Bullet gameobject value
    public GameObject bullet;
    // Time between shots value
    private float timeUntilFire = 0;

   

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
