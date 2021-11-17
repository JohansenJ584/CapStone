using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchBook : MonoBehaviour
{
    [SerializeField]
    GameObject[] tabs;


    public void Start()
    {
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
    }
}
