using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNAEditor : MonoBehaviour
{

    [SerializeField]
    GameObject DNAEditingTab;

    [SerializeField]
    DNAStrand[] heldDNA;

    [SerializeField]
    InventorySlot[] inventorySlots;



    public int shownInventorySlots;

    private int inventoryIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        inventorySlots = new InventorySlot[shownInventorySlots];
    }

    public void FinishEditing()
    {
        DNAEditingTab.SetActive(false);
        print("dna synthesized");
    }

    public void ShiftInventoryRight()
    {
        inventoryIndex += shownInventorySlots;
        if (inventoryIndex >= heldDNA.Length)
        {
            inventoryIndex = 0;
        }
        PopulateDNAInventory();
    }

    public void ShiftInventoryLeft()
    {
        inventoryIndex -= shownInventorySlots;
        if (inventoryIndex >= 0)
        {
            inventoryIndex = heldDNA.Length - shownInventorySlots;
        }
        PopulateDNAInventory();
    }

    void PopulateDNAInventory()
    {
        for (int i = 0; i < shownInventorySlots; i++)
        {
            inventorySlots[i].SetSlot(heldDNA[inventoryIndex + i]);
        }
    }

}
