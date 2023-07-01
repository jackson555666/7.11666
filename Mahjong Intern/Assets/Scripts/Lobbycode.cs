using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lobbycode : MonoBehaviour
{
    public string inputdata;
    public TMP_InputField codeInputField;

    private void Awake()
    {
        //Carry object to other scenes
        DontDestroyOnLoad(this.gameObject);

    }
    private void OnLevelWasLoaded(int level)
    {
        Invoke("codecheck", 0.1f);

    }

    //this run when transition to next scene
    public void Codecheck()
    {
        GameObject codetext = GameObject.Find("TextRoomCode");

        //check if found the TextRoomCode object and check if we input any code from Start scene
        if (codetext != null && !string.IsNullOrEmpty(inputdata))
        {
            codetext.GetComponent<TextMeshProUGUI>().text = "Room code: " + inputdata;
        }
    }
    public void GetCodeFromInputField()//this run when click start button
    {
        //this old code check if inputField gameobject exist instead of the text in inputField
        //if (codeInputField != null)
        //    inputdata = codeInputField.text;

        //when check if string or text is empty, try use IsNullOrEmpty instead
        if (!string.IsNullOrEmpty(codeInputField.text))
            inputdata = codeInputField.text;
    }

}
