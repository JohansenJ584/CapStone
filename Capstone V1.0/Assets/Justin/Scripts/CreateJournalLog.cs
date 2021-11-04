using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateJournalLog : MonoBehaviour
{
    public GameObject tempButton;
    void OnEnable()
    {
        Debug.Log(EntityCreation._instance.differentEntityList[0].name);
        foreach (GameObject tGame in EntityCreation._instance.differentEntityList)
        {
            //Debug.Log("HMMMM");
            GameObject tempbutt = Instantiate(tempButton, gameObject.transform);
            tempbutt.GetComponent<ActivateButton>().DataForButton(tGame.GetComponent<EntityControler>().myData);
            GameObject temp3d = Instantiate(tGame, tempbutt.transform.GetChild(0));
            temp3d.transform.localScale = new Vector3(40f, 40f, 40f);
            temp3d.layer = 5;
            foreach (Transform child in temp3d.transform)
            {
                child.gameObject.layer = 5;
            }
        }
    }
    void OnDisable()
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    /* Start is called before the first frame update
    void Start()
    {
        GameObject tempButton = gameObject.transform.GetChild(0).gameObject;
        Debug.Log(EntityCreation._instance.differentEntityList[0].name);
        foreach (GameObject tGame in EntityCreation._instance.differentEntityList)
        {
            Debug.Log("HMMMM");
            GameObject temper = Instantiate(tempButton, gameObject.transform);
            Instantiate(tGame, temper.transform);
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
