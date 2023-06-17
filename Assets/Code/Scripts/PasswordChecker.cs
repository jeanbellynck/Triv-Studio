
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.IO;

public class PasswordChecker : MonoBehaviour
{
    public TMP_InputField inputField;
    private string correctPassword;

    [SerializeField]
    private UnityEvent onCorrectInput;

    private void Start()
    {

        string[] passwordList = File.ReadAllLines("Assets/PasswordListDoors.txt");
        if (passwordList.Length > 0)
        {
            int randomIndex = Random.Range(0, passwordList.Length);
            correctPassword = passwordList[randomIndex];
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = correctPassword;

            AdjustInputFieldWidth();
        }
    }

    public void CheckPassword()
    {
        if (inputField.text == correctPassword)
        {
            inputField.text = "correct";
            onCorrectInput?.Invoke();
        }
    }

    private void AdjustInputFieldWidth()
    {
        TextMeshProUGUI placeholderText = inputField.placeholder.GetComponent<TextMeshProUGUI>();
        float placeholderWidth = placeholderText.GetPreferredValues(placeholderText.text).x;
        inputField.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, placeholderWidth + 20); // + 20 for the padding... I think :) 
    }
}
