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

    public AudioSource soundEffects;

    public AudioClip bookTurn;
    public AudioClip bookClose;

    public bool logPanelOpened;

    public PauseMenuScript pauseMenuScript;

    #endregion SoundEffects

    #region Inventory

    public Transform InventoryTab;

    public List<EntityData> dataInventory = new List<EntityData>();
    List<GameObject> inventoryEntries = new List<GameObject>();
    public GameObject inventoryEntryPrefab;

    GameObject[] pages;
    GameObject[] rows;

    private void Start()
    {
        soundEffects = FindObjectOfType<AudioSource>();
        soundEffects.clip = bookTurn;
        logPanelOpened = false;
        ToggleTab(0);
    }

    public void PopulateInventory()
    {
        // audioSource = FindObjectOfType<AudioSource>();
        // ToggleTab(0);
        logPanelOpened = false;
        EntityData[] temp = FindObjectsOfType<EntityData>();
        dataInventory.Clear();
        foreach (EntityData curr in temp)
        {
            dataInventory.Add(curr);
        }

        for (int i = 0; i < dataInventory.Count; i++)
        {
            int page = i / 20;
            int row = (i % 20) / 4;
            int slot = i % 4;

            Transform parentObject = InventoryTab.GetChild(page).GetChild(0).GetChild(row).GetChild(slot);
            GameObject currentInst = Instantiate(inventoryEntryPrefab, parentObject);
            inventoryEntries.Add(currentInst);
        }
    }


    public void DepopulateInventory()
    {
        foreach (GameObject curr in inventoryEntries)
        {
            Destroy(curr);
        }

    }

    #endregion Inventory

    public void OnEnable()
    {

    }



    public void ToggleTab(int index)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            if (i == index)
            {
                tabs[i].SetActive(true);
                if (tabs[i].name == "Inventory Panel")
                {
                    PopulateInventory();
                }
            }
            else
            {
                tabs[i].SetActive(false);
                if (tabs[i].name == "Inventory Panel")
                {
                    DepopulateInventory();
                }
            }

            if (index == 1)
            {
                logPanelOpened = true;
            }
            else
            {
                logPanelOpened = false;
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
        soundEffects.clip = bookTurn;
        soundEffects.Play();
    }

    public void PlayBookClose()
    {
        /*        audioSource.clip = bookClose;
                audioSource.Play();*/
        if (logPanelOpened)
        {
            ToggleTab(0);
        }
        else
        {
            pauseMenuScript.CloseResearchLog();
        }
        logPanelOpened = false;

        soundEffects.clip = bookClose;
        soundEffects.Play();
        DepopulateInventory();
    }
    #endregion SoundFunctions
}

