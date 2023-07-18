
using Unity.VisualScripting;
using UnityEngine;

public class paralaxController : MonoBehaviour
{
   



    // source: https://www.youtube.com/watch?v=ZYZfKbLxoHI 
    Transform cam;
    Vector3 camStartPos;
    float distanceX;
    float distanceY;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;


    [Range(0.0025f, 0.01f)]
    public float parallaxSpeed;
    public bool fitSitzeToCam = true;


    void Start()
    {

        if (fitSitzeToCam)
        {
            transform.localScale = Vector3.one * (Camera.main.orthographicSize/9f); 
        }

        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;


        }

        BackSpeedCalculate(backCount);

    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) // find farthest bg
        {
            if ((backgrounds[i].transform.position.z-cam.position.z > farthestBack))
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z ) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distanceX = cam.position.x - camStartPos.x;
        distanceY = cam.position.y - camStartPos.y;
        transform.position = new Vector3(cam.position.x, cam.position.y, 0);
                
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distanceX, distanceY) * speed);
        }
    }

  
}
