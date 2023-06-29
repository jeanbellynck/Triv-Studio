
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PasswordChecker : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onCorrectInput;

    [SerializeField]
    InputFieldManager inputFieldManagerScript;

    [SerializeField]
    CanvasAppear canvasScript;
    private static int inputSelected = 0;
    public Color lmuGreen = new Color(0, 0.533f, 0.227f, 0.5f);
    public Color errorRed = new Color(0.878f, 0.247f, 0.329f, 0.5f);

    private void Start()
    {
        
    }
    public void inputChecker()
    {
        Debug.Log("Input Checker");
        if (inputSelected > 4)
            return;
        var colors = inputFieldManagerScript.inputs[inputSelected].colors;
        var inputField = inputFieldManagerScript.inputs[inputSelected];

        if (inputField.text == inputFieldManagerScript.correctPassword.Substring(inputSelected, 1))  //input of field is correct and matches password
        {
            colors.normalColor = lmuGreen;
            inputSelected++;

            selectInputField();

            if(inputSelected > 4)
            {
                EventSystem.current.SetSelectedGameObject(null); //deselect input field
                onCorrectInput?.Invoke();
            }
        }
        else
        {
            colors.selectedColor = errorRed;
            inputFieldManagerScript.inputs[inputSelected].text = ""; //delete input
            selectInputField();
        }
        //set colors to new colors
        inputField.colors = colors;
        //rerender the inputfield
        inputField.Rebuild(CanvasUpdate.PreRender);
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
                break;
            default:
                break;
        }
    }

    public void remainSelected()
    {
        selectInputField();
    }
}

