using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MainMenuState
{
    Main, Controls
}

public class MainMenuScript : MonoBehaviour
{
    public GameObject main;
    public GameObject options;
    UIActions action;
    MainMenuState state;

    private void Awake()
    {
        state = MainMenuState.Main;
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
        action.Pause.PauseGame.performed += _ => DetermineBack();
    }

    void DetermineBack()
    {
        switch (state)
        {
            case MainMenuState.Main:
                break;
            case MainMenuState.Controls:
                //Debug.Log("controls escape called");
                state = MainMenuState.Main;
                //CloseOptions();
                break;
            default:
                break;
        }
    }

    public void StartGame()
    {
        // Debug.Log("game started");
        // Insert path to scene name here to begin game. 
        // Make sure to include in Build Settings.
        SceneManager.LoadScene("Assets/BuildMe/FinshWorld.unity");
    }
    public void ExitGame()
    {
        Application.Quit();
        // EditorApplication.Exit(0);
    }

    public void OpenOptions()
    {
        options.SetActive(true);
        main.SetActive(false);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
        main.SetActive(true);
    }
}