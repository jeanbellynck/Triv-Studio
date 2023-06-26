using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


        void Shoot()
        {
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        }
    }

}
