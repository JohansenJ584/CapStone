using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnityCreation : MonoBehaviour
{
    bool once = true;
    public GameObject DNATab;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController pCon))
        {
            if(Input.GetKey(KeyCode.F) && once)
            {
                DNATab.SetActive(true);
                DNATab.GetComponent<DNAEditor>().PopulateInventory();
                Cursor.lockState = CursorLockMode.Confined;
                once = false;
                //EntityCreation._instance.StartCreationTest();
            }
        }
    }
}
