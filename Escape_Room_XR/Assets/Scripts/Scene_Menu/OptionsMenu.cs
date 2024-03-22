using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    //Resolution[] resolutions;
    //public TMP_Dropdown resolutionDropDown;

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    //public void SetFullScreen(bool isFullScreen)
    //{
    //    Screen.fullScreen = isFullScreen;
    //}

    private void Start()
    {
        //resolutions = Screen.resolutions;
        ////the resolution saved in the array will be the possible resolutions.

        //resolutionDropDown.ClearOptions();
        ////causes the dropdown to be empty.

        //int currentResolutionIndex = 0;
        //List<string> options = new List<string>();
        //for (int i = 0; i < resolutions.Length; i++)
        //{
        //    string option = resolutions[i].width + " x " + resolutions[i].height;
        //    options.Add(option);

        //    if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        //    {
        //        currentResolutionIndex = i;
        //    }
        //    //We check if the item in the list is equal to ur current resolution.
        //    //If it is we set the index to the index of the list.
        //}
        ////create different resolutions available by specific PC builds.
        //// only possible in a list bc AddOptions only accepts lists.

        //resolutionDropDown.AddOptions(options);
        //resolutionDropDown.value = currentResolutionIndex;
        ////We call the value of the dropdown and place the index into the drowndown.
        ////Afterwards we refresh the value. SO it is correct for sure.
        //resolutionDropDown.RefreshShownValue();


    }

    //public void SetResoultion(int resolutionIndex)
    //{
    //    Resolution resolution = resolutions[resolutionIndex];
    //    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    //}

}
