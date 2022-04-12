using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNAEditor : MonoBehaviour
{
    #region StrandSlots

    [SerializeField]
    public Transform slot1Transform;

    [SerializeField]
    public Transform slot2Transform;

    [SerializeField]
    public Transform newSlotTransform;

    DNAStrand strandSlot1;

    GameObject strandSlot1ButtonPair;

    DNAStrand strandSlot2;

    GameObject strandSlot2ButtonPair;

    private DNAStrand newStrand;

    #endregion StrandSlots


    #region Buttons

    public bool selectingStrand1 = false;
    public bool selectingStrand2 = false;


    #endregion Buttons



    public GameObject inventoryStrandPrefab;
    public GameObject newStrandPrefab;

    [SerializeField]
    GameObject DNAEditingTab;

    public List<EntityData> dataInventory;

    [SerializeField]
    public VerticalLayoutGroup inventorySlots;


    #region Singleton

    private static DNAEditor _instance;

    public static DNAEditor Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DNAEditor>();
            }

            return _instance;
        }
    }

    #endregion Singleton

    void Start()
    {
        newStrand = Instantiate(newStrandPrefab).GetComponent<DNAStrand>();
        DisplayStrands();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void FinishEditing()
    {
        DNAEditingTab.SetActive(false);
        print("dna synthesized");
    }


    public void SetSlot1(DNAStrand set)
    {
        if (selectingStrand1)
        {
            strandSlot1 = set;
            DisplayStrands();
        }
        selectingStrand1 = false;
    }

    public void SetSlot2(DNAStrand set)
    {
        if (selectingStrand2)
        {
            ResetStrands();
            strandSlot2 = set;
            DisplayStrands();
        }
        selectingStrand2 = false;
    }



    public void SetStrandGene(int i, int gene)  
    {
        newStrand.SetLocalGene(i, gene);
    }

    public void DisplayStrands()
    {

        if (strandSlot1)
        {
            GameObject editorStrand = Instantiate(strandSlot1.gameObject);
            editorStrand.transform.SetParent(slot1Transform);
            editorStrand.GetComponent<RectTransform>().localScale = Vector3.one;
            editorStrand.transform.localPosition = Vector3.zero;
        }

        if (strandSlot2)
        {
            GameObject editorStrand = Instantiate(strandSlot2.gameObject);
            editorStrand.GetComponent<RectTransform>().localScale = Vector3.one;    
            editorStrand.transform.SetParent(slot2Transform);
            editorStrand.transform.localPosition = Vector3.zero;
        }

        if (strandSlot1 || strandSlot2)
        {
            newStrand.GetComponent<RectTransform>().localScale = Vector3.one;
            newStrand.transform.SetParent(newSlotTransform);
            newStrand.transform.localPosition = Vector3.zero;
        }

        DisableInventoryButtons();
    }

    void DisableInventoryButtons()
    {

        foreach (Transform child in inventorySlots.transform)
        {
            if (child.GetComponentInChildren<DNAStrand>() == strandSlot1 || child.GetComponentInChildren<DNAStrand>() == strandSlot2)
            {
                child.GetComponent<Button>().enabled = false;
            }
            else
            {
                child.GetComponent<Button>().enabled = true;
            }
        }


    }

    public void MakeTestStrand()
    {
        GameObject inventoryButtonGO = Instantiate(inventoryStrandPrefab, inventorySlots.transform);
        inventoryButtonGO.transform.localPosition = Vector3.zero;
        inventoryButtonGO.GetComponent<Button>().onClick.AddListener(delegate { SetSlot1(inventoryButtonGO.GetComponentInChildren<DNAStrand>()); });
        inventoryButtonGO.GetComponent<Button>().onClick.AddListener(delegate { SetSlot2(inventoryButtonGO.GetComponentInChildren<DNAStrand>()); });

    }

    void ResetStrands()
    {
        if (strandSlot1)
        {
            foreach (Transform child in slot1Transform)
            {
                Destroy(child.gameObject);
            }
        }
        
        if (strandSlot2)
        {
            foreach (Transform child in slot2Transform)
            {
                Destroy(child.gameObject);
            }
        }
     
    }

    public void StartSelectingSlot1()
    {
        selectingStrand1 = true;
    }
    public void StartSelectingSlot2()
    {
        selectingStrand2 = true;
    }


    public void PopulateInventory()
    {
        // Debug.Log("populate inventory");
        dataInventory = ResearchBook.dataInventory;
        // dataInventory = ResearchBook.dataInventory;
        foreach (Transform curr in inventorySlots.transform)
        {
            Destroy(curr.gameObject);
        }

        foreach (EntityData curr in dataInventory)
        {
            GameObject inventoryButtonGO = Instantiate(inventoryStrandPrefab, inventorySlots.transform);
            inventoryButtonGO.GetComponentInChildren<DNAStrand>().InitEntityData(curr);
            //inventoryButtonGO.transform.localPosition = Vector3.zero;
            // Debug.Log(curr.CreatureName);
        }


    }
}
