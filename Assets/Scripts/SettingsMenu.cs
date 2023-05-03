using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer m_audioMixer;
    public TMP_Dropdown resDropdown;
    Resolution[] resolution;

    private void Start()
    {
        resolution = Screen.resolutions;
        int currentRes = 0;

        List<string> resOptions = new List<string>();

        for (int i = 0; i < resolution.Length; i++)
        {
            string res = resolution[i].width + "x" + resolution[i].height;
            resOptions.Add(res);

            if (resolution[i].width == Screen.currentResolution.width && resolution[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        resDropdown.ClearOptions();
        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentRes;
        resDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);

        m_audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
    }

    public void SaveVolume()
    {
        PlayerPrefs.Save();
    }

    public void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void SetResolution(int index)
    {
        Resolution resolutions = resolution[index];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }
}
