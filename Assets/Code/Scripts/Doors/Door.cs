using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour  
{
    private Animator animator;

    //inspired by https://www.youtube.com/watch?v=1IJmenD1HOk
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    //to test easier, you can call the trigger directly from the inspector
    [ContextMenu("Open")]
    public void Open()
    {
        animator.SetTrigger("Open");
    }
    
}
