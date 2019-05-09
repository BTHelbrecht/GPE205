using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringMechanism : MonoBehaviour
{
    public float fireRate = 3;
    public float damage = 15;
    float timeUntilFire = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > timeUntilFire)
        {
            timeUntilFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Shooting");
    }
}
