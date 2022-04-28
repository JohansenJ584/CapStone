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

    public Button synthesizeButton;


    #endregion Buttons

    public GameObject inventoryStrandPrefab;
    public GameObject newStrandPrefab;

    [SerializeField]
    GameObject DNAEditingTab;

    public List<EntityData> dataInventory;

    [SerializeField]
    public GridLayoutGroup inventorySlots;


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

    }

    public void FinishEditing()
    {
        synthesizeButton.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SynthesizeNewDNA();
        strandSlot1 = null;
        strandSlot2 = null;
        foreach (Transform t in slot1Transform)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in slot2Transform)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in newSlotTransform)
        {
            Destroy(t.gameObject);
        }
        DisplayStrands();
        DNAEditingTab.SetActive(false);


        print("dna synthesized");
    }


    public void SetSlot1(DNAStrand set)
    {
        if(slot1Transform.childCount >= 1)
        {
            Destroy(slot1Transform.GetChild(0).gameObject);
        }
        strandSlot1 = set;
        DisplayStrands();

    }

    public void SetSlot2(DNAStrand set)
    {
        if (slot2Transform.childCount >= 1)
        {
            Destroy(slot2Transform.GetChild(0).gameObject);
        }
        strandSlot2 = set;
        DisplayStrands();
    }



    public void SetStrandGene(int i, int gene)  
    {
        newStrand.SetLocalGene(i, gene);
    }

    public void DisplayStrands()
    {
        if (strandSlot1) //&& slot1Transform.childCount == 0)
        {
            print("slot 1 exists");
            GameObject editorStrand = Instantiate(strandSlot1.gameObject);
            editorStrand.transform.SetParent(slot1Transform);
            editorStrand.GetComponent<RectTransform>().localScale = Vector3.one;
            editorStrand.transform.localScale = new Vector3(2.2f, 2.5f, 2);
            editorStrand.transform.localPosition = Vector3.zero;
        }

        if (strandSlot2)// && slot2Transform.childCount == 0)
        {
            print("slot 2 exists");
            GameObject editorStrand = Instantiate(strandSlot2.gameObject);
            editorStrand.transform.SetParent(slot2Transform);
            editorStrand.GetComponent<RectTransform>().localScale = Vector3.one;
            editorStrand.transform.localScale = new Vector3(2.2f, 2.5f, 2);
            editorStrand.transform.localPosition = Vector3.zero;
        }

        if (strandSlot1 || strandSlot2)
        {
            if (newStrand == null)
            {
                newStrand = Instantiate(newStrandPrefab).GetComponent<DNAStrand>();
            }
            newStrand.transform.SetParent(newSlotTransform);
            newStrand.transform.localPosition = Vector3.zero;
            newStrand.transform.localScale = new Vector3(2.2f, 2.5f, 2);
            newStrand.strandImage.color = CalculateNewStrandColor(strandSlot1, strandSlot2);
            synthesizeButton.interactable = true;
        }

        DisableInventoryButtons();
    }

    Color CalculateNewStrandColor(DNAStrand one, DNAStrand two)
    {
        float r = 0;
        float g = 0;
        float b = 0;
        if (one)
        {
            r += one.strandImage.color.r;
            g += one.strandImage.color.g;
            b += one.strandImage.color.b;
        }
        if (two)
        {
            r += two.strandImage.color.r;
            g += two.strandImage.color.g;
            b += two.strandImage.color.b;
        }
        if (one && two)
        {
            r /= 2;
            g /= 2;
            b /= 2;
        }
        return new Color(r, g, b);

    }

    void SynthesizeNewDNA()
    {
        List<EntityData> dataList = new List<EntityData>();
        dataList.Add(strandSlot1.entityData);
        dataList.Add(strandSlot2.entityData);
        PauseMenuScript.AddToInventory(EntityCreation._instance.CombineTwoOrMoreEntitys(dataList, true));
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
        dataInventory = PauseMenuScript.dataInventory;

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
