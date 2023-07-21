using UnityEngine;
using System.Collections;

public class LookToPlayer : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float rotationModifier;
    private Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public string followMe = "LMUMan";
    public Vector3 relativeDisplacement = new Vector3(-10, 10, 0);

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null) Debug.LogWarning("Player not Found: Enemy/LookToPlayer");
        target=player.transform;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            //position/velocity
            Vector3 targetPosition = target.TransformPoint(relativeDisplacement);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            //roation
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        else
        {
            Debug.LogWarning("Player not Found: Enemy/LookToPlayer/FixedUpdate");
        }

    }


}