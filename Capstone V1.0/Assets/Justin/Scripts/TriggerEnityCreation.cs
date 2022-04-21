using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnityCreation : MonoBehaviour
{
    public GameObject DNATab;
    public static bool DNAopened;

    private void Start()
    {
        DNAopened = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController pCon))
        {
            if(Input.GetKeyUp(KeyCode.F))
            {
                DNAopened = true;
                Debug.Log("get key F called");
                DNATab.SetActive(true);
                DNATab.GetComponent<DNAEditor>().PopulateInventory();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            if (Input.GetKeyUp(KeyCode.Escape) && DNAopened)
            {
                DNAopened = false;

                Debug.Log("closing trigger enity creation called");

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                DNATab.SetActive(false);
            }
        }
    }
}
