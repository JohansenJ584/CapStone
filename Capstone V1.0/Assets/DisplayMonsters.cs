using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMonsters : MonoBehaviour
{
    [SerializeField]
    PauseMenuScript pmenu; 
    private List<EntityData> listData;
    void Start()
    {
        // listData = pmenu.rb.dataInventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
