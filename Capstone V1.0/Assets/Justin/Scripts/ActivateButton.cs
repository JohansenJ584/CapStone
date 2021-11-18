using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateButton : MonoBehaviour
{
    protected EntityData buttonData;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => DoButton());
    }
    void DoButton()
    {
        DisplayLog.DisplayEntityInfo(buttonData);
    }

    public void DataForButton(EntityData tData) 
    {
        //Debug.Log("tData made");
        buttonData = tData;
    }
}
