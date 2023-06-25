using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingData : MonoBehaviour
{
    private void Awake()
    {
        //Carry object to other scenes
        DontDestroyOnLoad(this.gameObject);
    }

    //public Image changeBackgroundcolor;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    //Start is called before first frame update
    void start()
    {
        //Setting variables
        resolutions = Screen.resolutions;

        //Clear resolution dropdown options
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
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

    //public void changeNavyBlue()
    //{
    //    changeBackgroundcolor.color = new Color32(21, 34 ,56,255);
    //}
}
