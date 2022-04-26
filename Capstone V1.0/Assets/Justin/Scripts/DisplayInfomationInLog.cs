using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInfomationInLog : MonoBehaviour
{
    static public EntityData creatureData;

    [SerializeField]
    GameObject showCreature;
    [SerializeField]
    GameObject discribeCreature;
    [SerializeField]
    GameObject displayCamera;

    private GameObject curEntity;
    private void OnEnable()
    {
        //This is the raw image with the creaTURE
        if (creatureData)
        {
            curEntity = EntityCreation._instance.OnFinshDisplay(creatureData, displayCamera.transform.position + new Vector3(0f, -0.75f, 2.0f));
            curEntity.transform.LookAt(displayCamera.transform.position);
            curEntity.transform.Rotate(new Vector3(10,0f,0));
            curEntity.transform.parent = displayCamera.transform;
            //TextComponent
            showCreature.transform.GetChild(1).GetComponent<TMP_Text>().text = creatureData.CreatureName.Split(' ')[0];
            discribeCreature.transform.GetChild(1).GetComponent<TMP_Text>().text = creatureData.CreatureName.Split(' ')[1];

            discribeCreature.transform.GetChild(2).GetComponent<TMP_Text>().text = "Total Limbs:  " + creatureData.NumberOfComponents + "\n" +
                                                                                   "Body:  " + creatureData.MainBody.name + "\n" + 
                                                                                   "Whats Requried:\n" + displayList(creatureData.RequiredPlacement);
        }
    }

    private string displayList(List<StructHaveToPlace> tList)
    {
        string tStr = "";
        foreach (StructHaveToPlace i in tList)
        {
            if(i.WhatSide == 0)
            {
                //Top
                tStr += "   " + i.HowMany + " Head(s) requred.\n";
            }
            else if (i.WhatSide == 1)
            {
                //Bottom
                tStr += "   " + i.HowMany + " Leg(s) requred.\n";
            }
            else if (i.WhatSide == 2)
            {
                //Right
                tStr += "   " + i.HowMany + " Right arm(s) requred.\n";
            }
            else if (i.WhatSide == 3)
            {
                //Left
                tStr += "   " + i.HowMany + " Left arm(s) requred.\n";
            }
            else if (i.WhatSide == 4)
            {
                //Forward
                tStr += "   " + i.HowMany + " Back piece(s) requred.\n";
            }
            else if (i.WhatSide == 5)
            {
                //Back
                tStr += "   " + i.HowMany + " Front Piece(s) requred.\n";
            }
        }
        return tStr;
    }

    private void OnDisable()
    {
        Destroy(curEntity);
    }
}
