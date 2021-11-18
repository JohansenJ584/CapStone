using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResearchBook : MonoBehaviour
{
    [SerializeField]
    GameObject[] tabs;

    [SerializeField]
    TMP_Dropdown resolutionPicker;

    [SerializeField]
    Toggle fullscreenToggle;

    #region SoundEffects

    private AudioSource audioSource;

    public AudioClip bookTurn;
    public AudioClip bookClose; 

    #endregion SoundEffects

    public void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        ToggleTab(0);
    }

    public void ToggleTab(int index)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            if (i == index)
            {
                tabs[i].SetActive(true);
            }
            else
            {
                tabs[i].SetActive(false);
            }
        }

        PlayBookTurn();

 
    }

    public void OnChooseResolution()
    {
        switch (resolutionPicker.value)
        {
            case 0:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(2560, 1440, Screen.fullScreen);
                break;
        }
    }

    public void OnToggleFullscreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    #region SoundFunctions

    public void PlayBookTurn()
    {
        audioSource.clip = bookTurn;
        audioSource.Play();
    }

    public void PlayBookClose()
    {
        audioSource.clip = bookClose;
        audioSource.Play();
    }
    #endregion SoundFunctions
}

