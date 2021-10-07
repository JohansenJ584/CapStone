using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject main;
    public GameObject options;

    public void StartGame()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        options.SetActive(true);
        main.SetActive(false);
    }
}
