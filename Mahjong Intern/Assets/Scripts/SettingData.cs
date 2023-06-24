using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingData : MonoBehaviour
{
    private void Awake()
    {
        //Carry object to other scenes
        DontDestroyOnLoad(this.gameObject);
    }
}
