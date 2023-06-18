using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 motion;

    /// <summary>
    /// Returns the traveled distance of the player.
    /// </summary>
    public float Distance { get; private set; }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position;
        motion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(motion * speed * Time.deltaTime);
        var newPosition = transform.position;
        Distance += Vector3.Distance(currentPosition, newPosition);
    }
}
