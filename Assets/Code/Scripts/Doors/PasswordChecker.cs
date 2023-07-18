
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//inspired by https://www.youtube.com/watch?v=U8Py8nI-azc, https://discussions.unity.com/t/how-do-i-change-an-inputfields-color-in-onchangevalue/193322/2
public class PasswordChecker : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent onCorrectInput;

    [Header("Scripts")]
    [SerializeField]
    InputFieldManager inputFieldManagerScript;

    [SerializeField]
    CanvasAppear canvasScript;

    [SerializeField]
    PlaySound playSoundScript;

    [SerializeField]
    PlayerMovement playerMovementScript;

    [Header("Colors")]
    public Color lmuGreen = new Color(0, 0.533f, 0.227f, 0.5f);
    public Color errorRed = new Color(0.878f, 0.247f, 0.329f, 0.5f);

    private static int inputSelected = 0;

    private void Start()
    {
        //since the prefabs don't allow to reference other scene objects that aren't prefabs themselves, these references have to be added on runtime
        if (playSoundScript == null)
            playSoundScript = FindAnyObjectByType<PlaySound>();

        if (playerMovementScript == null)
            playerMovementScript = FindAnyObjectByType<PlayerMovement>();
    }

    public void inputChecker()
    {
        if (inputSelected > 4)
            return;
        var colors = inputFieldManagerScript.inputs[inputSelected].colors;
        var inputField = inputFieldManagerScript.inputs[inputSelected];

        if (inputField.text == inputFieldManagerScript.correctPassword.Substring(inputSelected, 1))  //input of field is correct and matches password
        {
            colors.normalColor = lmuGreen;
            inputSelected++;

            selectInputField();

            if (inputSelected > 4)
            {
                playSoundScript.playCorrectGuessSound();
                EventSystem.current.SetSelectedGameObject(null); //deselect input field
                onCorrectInput?.Invoke();
                playerMovementScript.animator.SetFloat("Horizontal", 10f);
                inputSelected = 0;
            }
        }
        else
        {
            colors.selectedColor = errorRed;
            playSoundScript.playWrongGuessSound();
            inputFieldManagerScript.inputs[inputSelected].text = "";
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