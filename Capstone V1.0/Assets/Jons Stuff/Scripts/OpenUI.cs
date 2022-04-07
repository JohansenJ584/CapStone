using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public GameObject ResearchBook;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResearchBook.SetActive(!ResearchBook.activeInHierarchy);
            if (ResearchBook.activeInHierarchy)
            {
               ResearchBook.GetComponentInParent<ResearchBook>().ToggleTab(0);
               Cursor.lockState = CursorLockMode.None;
            }
            else
            {
               Cursor.lockState = CursorLockMode.Locked;
               ResearchBook.GetComponentInParent<ResearchBook>().PlayBookClose();
            }
        }

    }

}
