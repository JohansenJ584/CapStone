using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMonsters : MonoBehaviour
{
    private List<EntityData> listData;
    void Start()
    {
        listData = PauseMenuScript.dataInventory;
        InvokeRepeating("UpdateEverySecond", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void UpdateEverySecond()
    {
        for(int i = 0; i < gameObject.transform.childCount - 1; i++)    
        {
            if (i < listData.Count)
            {
                if (transform.GetChild(i).childCount == 2 && listData[i] != gameObject.transform.GetChild(i).GetChild(1).GetComponent<EntityControler>().myData)
                {
                    Destroy(transform.GetChild(i).GetChild(1));
                    GameObject go = EntityCreation._instance.CopyOfEntity(listData[i], gameObject.transform.GetChild(i).position + new Vector3(0f,1.5f,0f));
                    go.transform.parent = gameObject.transform.GetChild(i);
                    go.transform.Rotate(Vector3.up, 180);
                    go.GetComponent<EntityControler>().whatNewColor();
                    go.GetComponent<EntityControler>().finshItUp();
                }
                else if (transform.GetChild(i).childCount == 1)
                {
                    GameObject go = EntityCreation._instance.CopyOfEntity(listData[i], gameObject.transform.GetChild(i).position + new Vector3(0f, 1.5f, 0f));
                    go.transform.parent = gameObject.transform.GetChild(i);
                    go.transform.Rotate(Vector3.up, 180);
                    go.GetComponent<EntityControler>().whatNewColor();
                    go.GetComponent<EntityControler>().finshItUp();
                }
            }
            else
            {
                break;
            }
        }
    }
}
