using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    public float colissionRadius = 0.4f;
    public bool collided = false;
    public LayerMask Ground;
    public Transform Bullet;
    public GameObject explosion;
    public int damage = 25;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            HPtracker Damager = hitInfo.GetComponent<HPtracker>();
            if (Damager != null)
            {
                Damager.TakeDamage(25);
            }
            Debug.Log(hitInfo.name);

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().die();


            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        
    }
}
