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

    public void codecheck()
    {
        GameObject codetext = GameObject.Find("TextRoomCode");
        Debug.Log(codetext != null);
        if (codetext != null)
        {
            codetext.GetComponent<TextMeshProUGUI>().text = "Room code: " + inputdata;
        }
    }
    public void getCodeFromInputField()
    {
        if (codeInputField != null)
            inputdata = codeInputField.text;
    }

}
