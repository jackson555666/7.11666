using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEditor.PackageManager;
using System;

public class SettingData : MonoBehaviour
{
    public static SettingData instance;
    public Color savedColor;
    public string roomCodeData;
    private bool flag = false;


    private void Awake()
    {
        //if (flag != true)
        //{
            if (instance == null && instance != this)
            {
                instance = this;
                //Carry object to other scenes
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }

    //private void OnLevelWasLoaded()
    //{
    //    flag = true;
    //}

    public void SetRoomCodeData(string roomCode)
    {
        roomCodeData = roomCode;
    }
}
