using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryStrandHandler : MonoBehaviour
{
    Vector3 startPos;
    bool init = false;
    private bool dragging;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClick()
    {
        print("clicked");
        startPos = transform.localPosition;
        init = true;
        dragging = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            print("stopped");
            dragging = false;
            GameObject[] slots = GameObject.FindGameObjectsWithTag("StrandSlot");
            foreach (GameObject curr in slots)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(curr.GetComponent<RectTransform>(), Input.mousePosition))
                {
                    switch (curr.name)
                    {
                        case "Strand Slot 1":
                            DNAEditor.Instance.SetSlot1(GetComponentInChildren<DNAStrand>());
                            print("SS1");
                            return;
                        case "Strand Slot 2":
                            DNAEditor.Instance.SetSlot2(GetComponentInChildren<DNAStrand>());
                            print("SS2");
                            return;
                    }

                }
            }
        }
        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if (init)
        {
            transform.localPosition = startPos;
        }
        
        
    }
}
