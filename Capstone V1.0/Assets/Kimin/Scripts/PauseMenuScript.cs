using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject bg;
    public GameObject bgImage;
    public GameObject researchLog;
    UIActions action;
    public ResearchBook rb;

    public AudioSource soundEffects;

    public AudioClip UIOpen;
    public AudioClip UIClose;
    public AudioClip bookClose;


    public Transform dnaSynthesizerTransform;
    public GameObject synthesizeInteractUI;
    public GameObject DNAUI;


    Transform player;

    public void LateUpdate()
    {
        synthesizeInteractUI.SetActive(Vector3.Distance(player.position, dnaSynthesizerTransform.position) <= 2.0f 
            && !DNAUI.activeInHierarchy);

    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        action = new UIActions();
        InvokeRepeating("PopulateInventory", 1, 1);
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        isGamePaused = false;
        action.Pause.PauseGame.started += _ => DeterminePause();
    }

    private void DeterminePause()
    {
        if (!TriggerEnityCreation.DNAopened)
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        OpenUIAudio();
    }

    public void PauseGameForLoadingScreen()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CloseUIAudio();
        //TriggerEnityCreation.DNAopened = false;
    }

    public void LoadMainMenu()
    {
        // we have to set up the build to make this work.
        // should be set up at the end when we know which scenes to use. 
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenResearchLog()
    {
        PopulateInventory();
        rb.PlayBookTurn();
        bg.SetActive(false);
        bgImage.SetActive(false);
        researchLog.SetActive(true);
    }

    public void CloseResearchLog()
    {
        CloseBookAudio();
        rb.DepopulateInventory();
        researchLog.SetActive(false);
        bg.SetActive(true);
        bgImage.SetActive(true);
    }

    public void openControl()
    {
        //controls.SetActive(true);
        bg.SetActive(false);
        bgImage.SetActive(false);
    }

    public void closeControl()
    {
        // controls.SetActive(false);
        bg.SetActive(true);
        bgImage.SetActive(true);
    }

    public void OpenUIAudio()
    {
        soundEffects.clip = UIOpen;
        soundEffects.Play();
    }

    public void CloseUIAudio()
    {
        soundEffects.clip = UIClose;
        soundEffects.Play();
    }

    public void CloseBookAudio()
    {
        soundEffects.clip = bookClose;
        soundEffects.Play();
    }



    #region Inventory

    public Transform InventoryTab;

    public static List<EntityData> dataInventory = new List<EntityData>();
    static List<GameObject> inventoryEntries = new List<GameObject>();
    public GameObject inventoryEntryPrefab;

    GameObject[] pages;
    GameObject[] rows;

    public void PopulateInventory()
    {
        //logPanelOpened = false;
        EntityData[] temp = FindObjectsOfType<EntityData>();
        DepopulateInventory();
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

    public static void AddToInventory(EntityData add)
    {
        dataInventory.Add(add);
    }



    public void DepopulateInventory()
    {
        foreach (GameObject curr in inventoryEntries)
        {
            Destroy(curr);
        }
    }

    #endregion Inventory
}