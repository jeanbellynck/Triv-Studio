using UnityEngine;
using System.Collections;

public class LookToPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float rotationModifier;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;


    void Update()
    {
       
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime );
    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

    }


}