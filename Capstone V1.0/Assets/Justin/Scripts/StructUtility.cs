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
    public StructComponentLocation(int whatComponent, Vector3 location)
    {
        WhatComponent = whatComponent;
        LocalLocation = location;
    }
    public int WhatComponent { get; }
    public Vector3 LocalLocation { get; } //THIS IS LOCAL LOCATION
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
