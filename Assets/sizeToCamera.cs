using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeToCamera : MonoBehaviour
{

    [SerializeField]private GameObject boundingBox;
    [SerializeField] private GameObject background;
    [SerializeField] private float boundingBoxFactor = 1f;
    [SerializeField] private float backgroundFactor = 9f;



    // Start is called before the first frame update
    void Start()
    {
        var cameraSize = Camera.main.orthographicSize;
        boundingBox.transform.localScale = new Vector3(1, 1, 0)* cameraSize * boundingBoxFactor;
        background.transform.localPosition = Vector3.one * cameraSize * backgroundFactor;

    }

    
}
