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

    [Header("�ػ󵵸� ������ �÷���")]
    List<Resolution> resolutions = new List<Resolution>();
    int currentResolutionIndex;                 // resolutionDropdown���� ���õ� value�� �����ϴ� ����. �̰��� ����� �����κ��� �ػ󵵸� ȣ���Ѵ�.

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
