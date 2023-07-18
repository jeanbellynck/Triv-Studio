using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionDetector : MonoBehaviour
{

    [SerializeField] public UnityEvent onPlayerStop;
    [SerializeField] public UnityEvent onPlayerStopDoor;
    [SerializeField] public UnityEvent onPlayerGo;
    [SerializeField] public UnityEvent onPlayerGoDoor;

    public float rayDistance;
    private bool firstCollisionEnterEvent = true;
    private bool firstCollisionExitEvent = false;
    [SerializeField] private LayerMask affectedLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkCollisions();

    }

    private void checkCollisions()
    {
        //https://www.youtube.com/watch?v=55bdhtQzzSA
        //int layermask = 1 << 5;
        //layermask = -layermask;


        //Vector2 rayOrigin = new Vector3(transform.position.x + 100f, transform.position.y - 20f, 0);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, rayDistance, affectedLayers); //origin, direction, distance, layers



        if (hitRight.collider != null)
        {
            Debug.Log($"collider hit: {hitRight.collider.name}");
            //makes sure the event triggers only once
            if (firstCollisionEnterEvent)
            {
                onPlayerStop?.Invoke();
                firstCollisionEnterEvent = false;
                firstCollisionExitEvent = true;
                Debug.Log($"coll enter: enter {firstCollisionEnterEvent}, exit {firstCollisionExitEvent}");
            }
        }
        else
        {
            if (firstCollisionExitEvent)
            {
                onPlayerGo?.Invoke();
                firstCollisionExitEvent = false;
                firstCollisionEnterEvent = true;
                Debug.Log($"coll exit: enter {firstCollisionEnterEvent}, exit {firstCollisionExitEvent}");
            }
        }
        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.red);
    }
}
