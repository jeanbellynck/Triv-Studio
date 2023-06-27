using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public float colissionRadius = 0.4f;
    public bool collided = false;
    public LayerMask Ground;
    public Transform Bullet;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed + new Vector3(1, 0, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        collided = Physics2D.OverlapCircle(Bullet.position, colissionRadius, Ground);

        if (collided)
        {
            Instantiate(explosion, Bullet.position, transform.rotation = Quaternion.identity);
            Destroy(gameObject);
        }
       
        if (!GetComponent<Renderer>().isVisible) Destroy(gameObject);
    }
}
