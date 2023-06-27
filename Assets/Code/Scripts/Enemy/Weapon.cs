using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float delay = 3;
    public float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            Shoot();
            timer = 0;
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }

}
