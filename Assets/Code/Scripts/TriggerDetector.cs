using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private UnityEvent triggerEntered;

    [SerializeField]
    private UnityEvent triggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerEntered.Invoke();
            collision.gameObject.GetComponent<UnityEngine.Animator>().SetFloat("Horizontal", 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerExit.Invoke();
            collision.gameObject.GetComponent<UnityEngine.Animator>().SetFloat("Horizontal", 10f);
        }
    }
}