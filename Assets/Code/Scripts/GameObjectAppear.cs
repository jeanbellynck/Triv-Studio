
using UnityEngine;
using TMPro;

public class GameObjectAppear : MonoBehaviour
{

    public bool hidden;
    public GameObject target;

    public void Start()
    {
        target.SetActive(!hidden);
    }

    public void letObjectAppear()
    {
        target.SetActive(hidden);
        Debug.Log($"set active {target.name}");
    }

    public void letObjectDisappear()
    {
        target.SetActive(!hidden);
        Debug.Log("set inactive");
    }

}
