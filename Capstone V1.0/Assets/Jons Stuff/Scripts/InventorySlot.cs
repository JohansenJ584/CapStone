using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    DNAStrand DNAObject;

    [SerializeField]
    Image InventoryImage;
    void Start()
    {
        
    }

    public void SetSlot(DNAStrand DNA)
    {
        DNAObject = DNA;
    }


    private void DisplayInInventory()
    {
        InventoryImage.sprite = DNAObject.Icon;
    }
}
