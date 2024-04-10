using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
    FullScreenMode screenmode;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenBtn;

    [Header("�ػ󵵸� ������ �ݷ���")]
    List<Resolution> resolutions = new List<Resolution>(0);
    int currentResolutionNum;  // resolutionDropDown���� ���õ� Value�� �����ϴ� ����. �̰��� ����� ������ ���� �ػ󵵸� ȣ���Ѵ�.

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

        foreach(var resolution in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = resolution.width + "x" + resolution.height + " " + resolution.refreshRateRatio + "HZ";

            resolutionDropdown.options.Add(option);

            if (resolution.width == Screen.width && resolution.height == Screen.height)
                resolutionDropdown.value = optionNum;

            optionNum++;
        }

        resolutionDropdown.RefreshShownValue();

        fullScreenBtn.isOn =
            Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropboxOptionChange()
    {
        currentResolutionNum = resolutionDropdown.value;
    }

    public void FullScreenButton()
    {
        screenmode = fullScreenBtn.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void ChangeResoultion()
    {
        Screen.SetResolution(
                             resolutions[currentResolutionNum].width,
                             resolutions[currentResolutionNum].height,
                             screenmode
                            );
    }

}
