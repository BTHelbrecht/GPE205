using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 4;

    // Update is called once per frame
    void Update()
    {
        Vector3 positon = transform.position;

        Vector3 moveBullet = new Vector3(0, bulletSpeed * Time.deltaTime, 0);

        positon += transform.rotation * moveBullet;

        transform.position = positon;
    }
}
