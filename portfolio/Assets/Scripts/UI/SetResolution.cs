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
    int currentResolutionIndex;

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
        int optionNum = 0;

        foreach (var item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRateRatio + "HZ";

            resolutionDropdown.options.Add(option);
        }
        
    }
}
