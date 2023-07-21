using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject explosion;
    public float delay = 3;
    public float timer;
    private GameObject player;
    private int shots = 0;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

    }
    void Update()
    {

        

        timer += Time.deltaTime;
        if (timer > delay && player.GetComponent<PlayerMovement>().moving)
        {
            Shoot();
            timer = 0;
        }
        else if (!player.GetComponent<PlayerMovement>().moving) {
            timer = 0;
        }
    }
    void Shoot()
    {
        if (shots >= 1)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }

        var position = FirePoint.position;
        position.z = 0;
        Instantiate(bulletPrefab, position, FirePoint.rotation);
        shots++;
       
    }

}
