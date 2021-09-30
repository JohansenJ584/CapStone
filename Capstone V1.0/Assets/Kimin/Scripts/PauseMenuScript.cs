using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenu;
   // public GameObject controls;
    public GameObject bg;

    void Awake()
    {
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
       // if (!GameState.isGameOver)
       // {
            if (Input.GetKeyDown(KeyCode.Escape))
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

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

    public void openControl()
    {
        //controls.SetActive(true);
        bg.SetActive(false);
    }

    public void closeControl()
    {
       // controls.SetActive(false);
        bg.SetActive(true);
    }
}