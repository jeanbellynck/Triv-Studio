using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_X : MonoBehaviour
{

    [SerializeField]
    private GameObject follow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        if(follow.transform.position.x > transform.position.x)
        {
            newPos.x = follow.transform.position.x;
        }
        transform.position = newPos;
    }
}
