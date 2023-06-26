using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed + new Vector3(1, 0, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
