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

    private void Awake()
    {
        action = new UIActions();
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
        action.Pause.PauseGame.performed += _ => DeterminePause();

    }

    private void DeterminePause()
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

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
    }

    public void LoadMainMenu()
    {
        /*        SceneManager.LoadScene(0);
                Time.timeScale = 1f;
                isGamePaused = false;*/
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenResearchLog()
    {
        bg.SetActive(false);
        bgImage.SetActive(false);
        researchLog.SetActive(true);
    }

    public void CloseResearchLog()
    {
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
}