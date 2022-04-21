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
            if(Input.GetKey(KeyCode.F))
            {
                DNATab.SetActive(true);
                DNATab.GetComponent<DNAEditor>().PopulateInventory();
                Cursor.lockState = CursorLockMode.Confined;
                DNAopened = true;
            }
            if (Input.GetKey(KeyCode.Escape) && DNAopened)
            {
                Cursor.lockState = CursorLockMode.Locked;
                DNAopened = false;
                DNATab.SetActive(false);
            }
        }
    }
}
