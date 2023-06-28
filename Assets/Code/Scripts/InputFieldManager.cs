using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldManager : MonoBehaviour
{
    //get correct password from other script
    public string correctPassword;
    //split string and assign chars to respective input fields as placeholders
    //check in checkPassword if input in inputfield equal to correct char

    

    public TMP_InputField[] inputs;
    
    void Start()
    {
        correctPassword = "hallo";

        for(int i = 0; i < inputs.Length; i++)
        {
            inputs[i].placeholder.GetComponent<TextMeshProUGUI>().text = correctPassword.Substring(i, 1);
            Debug.Log("placeholder: round " + i + " | " + correctPassword.Substring(i, 1));
        }

        inputs[0].Select(); //select first input field automatically

    }


    
}
