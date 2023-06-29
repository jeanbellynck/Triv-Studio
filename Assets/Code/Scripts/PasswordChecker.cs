
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.IO;
using UnityEngine.EventSystems;
using System.Collections;

public class PasswordChecker : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onCorrectInput;

    [SerializeField]
    InputFieldManager inputFieldManagerScript;

    private static int inputSelected = 0;
    public void inputChecker()
    {
        if (inputFieldManagerScript.inputs[inputSelected].text == inputFieldManagerScript.correctPassword.Substring(inputSelected, 1))  //input of field is correct and matches password
        {
            inputSelected++;
            selectInputField();

            if(inputSelected > 4)
            {
                inputSelected = 0;
                onCorrectInput?.Invoke();
            }
        }
        else
        {
            inputFieldManagerScript.inputs[inputSelected].text = ""; //delete input
            selectInputField();
        }
    }


    void selectInputField()
    {
        switch (inputSelected)
        {
            case 0:
                inputFieldManagerScript.inputs[0].ActivateInputField();
                break;
            case 1:
                inputFieldManagerScript.inputs[1].ActivateInputField();
                break;
            case 2:
                inputFieldManagerScript.inputs[2].ActivateInputField();
                break;
            case 3:
                inputFieldManagerScript.inputs[3].ActivateInputField();
                break;
            case 4:
                inputFieldManagerScript.inputs[4].ActivateInputField();
                //and invoke onCorrectInput method to open the door
                break;
            default:
                break;
        }
    }

    public void remainSelected()
    {
        selectInputField();
        Debug.Log("remeinsSelected");
    }
}

