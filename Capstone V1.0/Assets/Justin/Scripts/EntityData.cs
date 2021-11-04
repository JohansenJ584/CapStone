using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This should go in a reference file
public struct StructComponentLocation
{
    public StructComponentLocation (int whatComponent, Vector3 location)
    {
        WhatComponent = whatComponent;
        LocalLocation = location;
    }
    public int WhatComponent { get; }
    public Vector3 LocalLocation { get; } //THIS IS LOCAL LOCATION
}
*/

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EntityData")]
public class EntityData : ScriptableObject
{
    string creatureName;
    GameObject mainBody;
    int numberOfComponents;
    List<int> whatComps; //DNA
    List<StructComponentLocation> whereAndWhatsOnMe = new List<StructComponentLocation>(); //need better names

    public GameObject MainBody { get => mainBody;}
    public int NumberOfComponents { get => numberOfComponents;}
    public string CreatureName { get => creatureName;}
    public List<int> WhatComps { get => whatComps; }
    public List<StructComponentLocation> WhereAndWhatsOnMe { get => whereAndWhatsOnMe; set => whereAndWhatsOnMe = value; }

    public void makeData(string tcreatureName, GameObject tmainBody, int tnumberOfComponents, List<int> tWhatComps)
    {
        this.creatureName = tcreatureName;
        this.mainBody = tmainBody;
        this.numberOfComponents = tnumberOfComponents;
        this.whatComps = tWhatComps;
    }
    public void makeData(EntityData otherData)
    {
        this.creatureName = otherData.CreatureName.Substring(0, (otherData.CreatureName.LastIndexOf('.') + 1)) + (System.Int32.Parse(otherData.CreatureName.Substring(otherData.CreatureName.LastIndexOf('.') + 1)) + 1).ToString();
        this.mainBody = otherData.MainBody;
        this.numberOfComponents = otherData.NumberOfComponents;
        this.whatComps = otherData.WhatComps;
        this.whereAndWhatsOnMe = new List<StructComponentLocation>(otherData.WhereAndWhatsOnMe.ToArray());
    }

    public void AddAStructComponentLocation(int whatComponent, Vector3 location)
    {
        whereAndWhatsOnMe.Add(new StructComponentLocation(whatComponent, location));
    }
}
