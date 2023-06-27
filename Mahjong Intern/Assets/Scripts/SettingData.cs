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
    public Image bgImage;
    public Image bgSetting;
    public Color savedColor;

    private void Awake()
    {
        //Carry object to other scenes
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded()
    {

    }

    //public Image changeBackgroundcolor;
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    //Start is called before first frame update
    void Start()
    {
        //Setting variables
        resolutions = Screen.resolutions;

        //Clear resolution dropdown options
        if(resolutionDropdown != null )
            resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //bgImage = GameObject.Find("Background").GetComponent<Image>();
        //bgSetting = GameObject.Find("SettingsWindow").GetComponent<Image>();

        //if we not sure it gonna find the game object everytime, try check != null or use "try" for safety
        try
        {
            bgImage = GameObject.Find("Background").GetComponent<Image>();
            bgSetting = GameObject.Find("SettingsWindow").GetComponent<Image>();
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString());
        }
    }



    public void ChangeBGColor(Image buttonColor)
    {
        bgImage = GameObject.Find("Background").GetComponent<Image>();
        bgSetting = GameObject.Find("SettingsWindow").GetComponent<Image>();
        savedColor = buttonColor.color;
        bgImage.color = savedColor;  //change BG color to color of the setting button
        ChangeSettingBGColor(buttonColor.color);    //also change the setting window BG color to the same tone but brighter
    }

    public void ChangeSettingBGColor(Color newColor)
    {
        //add two colors to make a brighter color
        bgSetting.color = new Color(0.15f, 0.15f, 0.15f) + newColor;
    }

    //Set resolution
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Toggle Fullscreen
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;   //Set fullscreen
    }

}
