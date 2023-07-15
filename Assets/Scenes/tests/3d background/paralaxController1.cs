
using Unity.VisualScripting;
using UnityEngine;

public class paralaxController1 : MonoBehaviour
{
   



    // source: https://www.youtube.com/watch?v=ZYZfKbLxoHI 
    Transform cam;
    Vector3 camStartPos;
    float distanceX;
    float distanceY;
    public float rotSpeed = 1;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;


    [Range(0.0025f, 0.01f)]
    public float parallaxSpeed;


    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

    }



    private void LateUpdate()
    {

        distanceX = cam.position.x - camStartPos.x;
        distanceY = cam.position.y - camStartPos.y;


        float rotationHorizontal = (distanceX * rotSpeed) % 360 ;
        float rotationLateral = 0;

        transform.position = new Vector3(cam.position.x, cam.position.y - 4.56f, transform.position.z);
        transform.Rotate(new Vector3(0, rotationHorizontal, 0));
        transform.rotation = Quaternion.Euler(0, rotationHorizontal, 0);
        


    }

  
}
