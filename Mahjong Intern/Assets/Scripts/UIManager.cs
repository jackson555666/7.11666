using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image bgImage;
    public Image bgSettingPanel;
    public TMP_InputField codeInputField;
    public TextMeshProUGUI currentRoomCodeText;

    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        InitialSettingResolution();
        InitialSyncSetting();
    }

    public void ChangeBGColor(Image buttonColor)
    {
        if (bgImage == null)
            return;

        if (SettingData.instance != null)
        {
            SettingData.instance.savedColor = buttonColor.color;
            bgImage.color = SettingData.instance.savedColor;  //change BG color to color of the setting button
        }
        
        ChangeSettingBGColor(buttonColor.color);    //also change the setting window BG color to the same tone but brighter
    }

    public void ChangeSettingBGColor(Color newColor)
    {
        //add two colors to make a brighter color
        bgSettingPanel.color = new Color(0.15f, 0.15f, 0.15f) + newColor;
    }

    void InitialSyncSetting()
    {
        if (SettingData.instance == null)
            return;

        if(bgImage!= null)
            bgImage.color = SettingData.instance.savedColor;

        if (bgSettingPanel != null)
            ChangeSettingBGColor(bgImage.color);

        if (currentRoomCodeText != null)
            SetRoomCodeText();

        SettingData.instance.SetRoomCodeData("");
    }

    void InitialSettingResolution()
    {
        if (resolutionDropdown == null)
            return;

        //Setting variables
        resolutions = Screen.resolutions;

        //Clear resolution dropdown options
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
    }

    //Set resolution
    public void SetResolution(int resolutionIndex)
    {
        if (resolutionDropdown == null)
            return;

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Toggle Fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;   //Set fullscreen
    }

    public void SetRoomCodeData()
    {
        if(SettingData.instance != null && codeInputField != null && !string.IsNullOrEmpty(codeInputField.text))
        {
            SettingData.instance.SetRoomCodeData(codeInputField.text);
        }
    }

    public void SetRoomCodeText()
    {
        if(!string.IsNullOrEmpty(SettingData.instance.roomCodeData))
        {
            currentRoomCodeText.text = "Room code: " + SettingData.instance.roomCodeData;
        }
    }
}
