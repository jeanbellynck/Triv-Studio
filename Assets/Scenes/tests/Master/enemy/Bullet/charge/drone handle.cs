using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    Weapon weapon;
    public GameObject Enemy;
    private Animator anim;
    
    // Start is called before the first frame update
    void Awake()
    {
        weapon = GameObject.Find("Enemy").GetComponent<Weapon>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if (weapon.timer > 1)
        {
            anim.SetBool("DroneHandle", true);
            Debug.Log("works");
        }
        
    }
}
