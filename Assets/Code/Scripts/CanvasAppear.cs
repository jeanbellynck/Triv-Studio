
using UnityEngine;
using TMPro;

public class CanvasAppear : MonoBehaviour
{

    public bool hidden;
    public Canvas canvas;

    public void Start()
    {
        canvas.enabled = !hidden;
    }

    public void letObjectAppear()
    {
        canvas.enabled = hidden;
    }

    public void letObjectDisappear()
    {
        canvas.enabled = !hidden;
    }

}
