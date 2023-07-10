using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObject : MonoBehaviour
{
    public string tagOldObject;
    public string tagNewObject;
    // Find the game object that you want to replace 

    public void replaceObject(string tagOldObject, string tagNewObject)
    {
        GameObject oldObject = GameObject.FindGameObjectWithTag(tagOldObject);
        Destroy(oldObject);

        // Instantiate the new object 
        GameObject newObject = Instantiate(GameObject.FindGameObjectWithTag(tagNewObject));

        // Set the position and rotation of the new object to match the old object 
        newObject.transform.position = oldObject.transform.position; 
        newObject.transform.rotation = oldObject.transform.rotation; 

    }

    // Destroy the old object 
}
