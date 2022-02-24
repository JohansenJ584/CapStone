using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EntityData")]
public class EntityData : ScriptableObject
{
    string creatureName;
    GameObject mainBody;
    int numberOfComponents;
    //List<int> whatComps; //DNA
    List<ComponentData> whatComps;
    List<StructComponentLocation> whereAndWhatsOnMe = new List<StructComponentLocation>(); //need better names
    List<StructHaveToPlace> requiredPlacement = new List<StructHaveToPlace>();

    //GETTERS
    public GameObject MainBody { get => mainBody;}
    public int NumberOfComponents { get => numberOfComponents;}
    public string CreatureName { get => creatureName;}
    
    //public List<int> WhatComps { get => whatComps; }
    public List<ComponentData> WhatComps { get => whatComps; }

    public List<StructHaveToPlace> RequiredPlacement { get => requiredPlacement; set => requiredPlacement = value; }

    public List<StructComponentLocation> WhereAndWhatsOnMe { get => whereAndWhatsOnMe; set => whereAndWhatsOnMe = value; }
    
    /// <summary>
    /// Constructor for data
    /// </summary>
    /// <param name="tcreatureName"></param>
    /// <param name="tmainBody"></param>
    /// <param name="tnumberOfComponents"></param>
    /// <param name="tWhatComps"></param>
    public void makeData(string tcreatureName, GameObject tmainBody, int tnumberOfComponents, List<ComponentData> tWhatComps, List<StructHaveToPlace> tRequiredPlacement)
    {
        this.creatureName = tcreatureName;
        this.mainBody = tmainBody;
        this.numberOfComponents = tnumberOfComponents;
        this.whatComps = tWhatComps;
        this.RequiredPlacement = tRequiredPlacement;
    }
    public void makeData(EntityData otherData)
    {
        this.creatureName = otherData.CreatureName.Substring(0, (otherData.CreatureName.LastIndexOf('.') + 1)) + (System.Int32.Parse(otherData.CreatureName.Substring(otherData.CreatureName.LastIndexOf('.') + 1)) + 1).ToString();
        this.mainBody = otherData.MainBody;
        this.numberOfComponents = otherData.NumberOfComponents;
        this.whatComps = otherData.WhatComps;
        this.whereAndWhatsOnMe = new List<StructComponentLocation>(otherData.WhereAndWhatsOnMe.ToArray());
    }

    public void AddAStructComponentLocation(ComponentData whatComponent, Vector3 location)
    {
        whereAndWhatsOnMe.Add(new StructComponentLocation(whatComponent, location));
    }
}
