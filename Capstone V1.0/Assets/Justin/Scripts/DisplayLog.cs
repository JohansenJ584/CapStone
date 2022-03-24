using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLog : MonoBehaviour
{
    public static DisplayLog _instance;
    public Text DisplayPort;

    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static void DisplayEntityInfo(EntityData data)
    {
        DisplayLog._instance.DisplayPort.text = "The Name of Creature:  " + data.CreatureName + "\n" +
                                                "How Many Total Components:  " + data.NumberOfComponents + "\n \n \n \n" +
                                                "What Components are aviable:  " + DisplayLog._instance.displayList(data.WhatComps);  
                                                 //MAYBE A FUN DISCREPTION static suuuuuucks my dude
    }

    private string displayList(List<ComponentData> tList)
    {
        string tStr = "[";
        foreach(ComponentData i in tList)
        {
            tStr += i.WhatComponent + ", ";
        }
        tStr += "]";
        return tStr;
    }
}
