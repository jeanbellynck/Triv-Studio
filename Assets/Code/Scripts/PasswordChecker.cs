
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.IO;

public class PasswordChecker : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onCorrectInput;

    [SerializeField]
    InputFieldManager inputFieldManagerScript;

    private int inputSelected = 0;
    public void inputChecker()
    {
        //Problem: wenn Password nicht korrekt, wird j inkrementiert und Schleife nicht nochmal wiederholt. Man kann also nur einmal pro Kasten checken
        Debug.Log("input method");
        for (int j = 0; j < inputFieldManagerScript.inputs.Length; j++)
        {
            Debug.Log("input: round " + j);
            if (inputFieldManagerScript.inputs[j].text == inputFieldManagerScript.correctPassword.Substring(j, 1))  //input of field is correct and matches password
            {
                inputSelected++;
                Debug.Log("input correct?");
                selectInputField();
            }
            else
            {
                inputFieldManagerScript.inputs[j].text = ""; //delete input
                Debug.Log("delete input");
            }
        }
    }

    void selectInputField()
    {
        switch (inputSelected)
        {
            case 0:
                inputFieldManagerScript.inputs[0].Select();
                break;
            case 1:
                inputFieldManagerScript.inputs[1].Select();
                break;
            case 2:
                inputFieldManagerScript.inputs[2].Select();
                break;
            case 3:
                inputFieldManagerScript.inputs[3].Select();
                break;
            case 4:
                inputFieldManagerScript.inputs[4].Select();
                onCorrectInput?.Invoke(); //and invoke onCorrectInput method to open the door
                break;
        }
    }
}
