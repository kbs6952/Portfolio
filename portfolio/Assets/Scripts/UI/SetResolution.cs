using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
    FullScreenMode fullScreenMode;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenBtn;

    [Header("해상도를 저장할 컬렉션")]
    List<Resolution> resolutions = new List<Resolution>();
    int currentResolutionIndex;                 // resolutionDropdown에서 선택된 value를 저장하는 변수. 이곳에 저장된 변수로부터 해상도를 호출한다.

    private void Start()
    {
        LoadComponents();
    }

    private void LoadComponents()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++) 
        {
            resolutions.Add(Screen.resolutions[i]);
        }

        resolutionDropdown.options.Clear();
        int optionNum = 0;

        foreach (var item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRateRatio + "HZ";

            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
                resolutionDropdown.value = optionNum;

            optionNum++;
        }

        resolutionDropdown.RefreshShownValue();

        fullScreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }
    public void DropBoxOptionChange()
    {
        currentResolutionIndex = resolutionDropdown.value;
    }
    public void FullScreenButton()
    {
        fullScreenMode = fullScreenBtn.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void ChangeResolution()
    {
        Screen.SetResolution(resolutions[currentResolutionIndex].width,
                             resolutions[currentResolutionIndex].height, fullScreenMode);
    }
}
