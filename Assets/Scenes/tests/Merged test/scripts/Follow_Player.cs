using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public GameObject target;
    private float distance;
    public float radius;
    public Rigidbody2D rb2d;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > radius)
        {
            rb2d.AddForce((target.transform.position - transform.position)  * speed);
        }
       
    
        
    }
}
