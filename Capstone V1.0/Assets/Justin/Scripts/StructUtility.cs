using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Chance of a component being used in the new monster.
public struct StructComponentChance
{
    public StructComponentChance(int whatComponent, float chance, bool isDommanent)
    {
        WhatComponent = whatComponent;
        Chance = chance;
        IsDommanent = isDommanent;
    }
    public int WhatComponent { get; }
    public float Chance { get; set; }
    public bool IsDommanent { get; }
}

//Location of a component of a monster
public struct StructComponentLocation
{
    public StructComponentLocation(ComponentData whatComponent, Vector3 location)
    {
        WhatComponentData = whatComponent;
        LocalLocation = location;
    }
    public ComponentData WhatComponentData { get; }
    public Vector3 LocalLocation { get; } 
}

public struct StructHaveToPlace
{
    public StructHaveToPlace(int whatSide, int howMany)
    {
        WhatSide = whatSide;
        HowMany = howMany;
        HowManyPlaced = 0;
    }
    public int WhatSide { get; }
    public int HowMany { get; set; }
    public int HowManyPlaced { get; set; }

    public void AddToPlaced()
    {
        HowManyPlaced += 1;
    }
}



public class StructUtility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
