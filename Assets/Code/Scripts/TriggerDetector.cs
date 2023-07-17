
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private string colliderScript;

    [SerializeField]
    private UnityEvent triggerEntered;

    [SerializeField]
    private UnityEvent triggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the game object has the script that is specified as the variable colliderScript
        if (collision.gameObject.GetComponent(colliderScript))
        {
            triggerEntered?.Invoke();
        }
    }

}
