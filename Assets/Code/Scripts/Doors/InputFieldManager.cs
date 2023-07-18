using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class InputFieldManager : MonoBehaviour
{
    private string[] passwordList;
    public string correctPassword;

    public TMP_InputField[] inputs;
    
    void Start()
    {
        passwordList = File.ReadAllLines("Assets/passwordListDoors.txt");
        int randomIndex = Random.Range(0, passwordList.Length);
        correctPassword = passwordList[randomIndex];

        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i].placeholder.GetComponent<TextMeshProUGUI>().text = correctPassword.Substring(i, 1);
            //Debug.Log("placeholder: round " + i + " | " + correctPassword.Substring(i, 1));
        }


        this.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    public void selectFirstInput()
    {
        Debug.Log("select first input");
        inputs[0].Select(); //select first input field automatically
    }
}
