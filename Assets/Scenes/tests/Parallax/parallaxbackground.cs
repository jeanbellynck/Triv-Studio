using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0f, 0.5f)]
    public float speed = 0.2f;
    public Vector2 direction = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;    
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime*speed;
        mat.SetTextureOffset("_MainTex", direction * distance);


    }
}
