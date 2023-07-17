using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    Weapon weapon;
    public GameObject Enemy;
    private UnityEngine.Animator anim;
    
    // Start is called before the first frame update
    void Awake()
    {
        weapon = GameObject.Find("Enemy").GetComponent<Weapon>();
        anim = GetComponent<UnityEngine.Animator>();
    }

    // Update is called once per frame

}
