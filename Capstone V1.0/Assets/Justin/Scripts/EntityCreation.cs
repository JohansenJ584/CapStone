using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

/*This should go in a reference file
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
    public bool IsDommanent {get;}
}
*/

public class EntityCreation : MonoBehaviour
{
    public static EntityCreation _instance;

    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            //Rest of Awake code
            //Below here

        }
        else
        {
            Destroy(this);
        }
    }

    public List<GameObject> differentEntityList = new List<GameObject>();

    public GameObject tempUI;
    public Transform TestSpawnLocation;
    public GameObject TestBody;
    public List<GameObject> allBodyComponents; //This is just temporary

    public GameObject tempImagePrefab;
    public int whatValueSelection = 0;
    public List<Sprite> allSprites;


    //https://www.raywenderlich.com/3169311-runtime-mesh-manipulation-with-unity
    // Start is called before the first frame update
    void Start()
    {
        string name = "Test_1.0";
        GameObject mainBody = TestBody;
        int numberOfComponents = 4;
        List<int> testList = new List<int> {0, 1, 2, 3, 4};
        EntityData testData = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData.makeData(name, mainBody, numberOfComponents, testList);
        BrandNewEntity(testData, new Vector3(0f, 1f, -10f));
        CopyOfEntity(testData, new Vector3(0f, 3f, -10f));


        string name1 = "Test_2.0";
        GameObject mainBody1 = TestBody;
        int numberOfComponents1 = 7;
        List<int> testList1 = new List<int> { 0, 1, 2, 2, 4, 7, 8 };
        EntityData testData1 = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData1.makeData(name1, mainBody1, numberOfComponents1, testList1);
        BrandNewEntity(testData1, new Vector3(3f, 1f, -10f));
        CopyOfEntity(testData1, new Vector3(3f, 3f, -10f));

        string name2 = "Test_3.0";
        GameObject mainBody2 = TestBody;
        int numberOfComponents2 = 9;
        List<int> testList2 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        EntityData testData2 = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData2.makeData(name2, mainBody2, numberOfComponents2, testList2);
        BrandNewEntity(testData2, new Vector3(6f, 1f, -10f));
        CopyOfEntity(testData2, new Vector3(6f, 3f, -10f));


        List<EntityData> testEntitys = new List<EntityData>();
        testEntitys.Add(testData);
        testEntitys.Add(testData);
        testEntitys.Add(testData1);
        testEntitys.Add(testData2);

        CombineTwoOrMoreEntitys(testEntitys);
    }

    void CopyOfEntity(EntityData tempData, Vector3 vecWhere)
    { 
        //NEED NEW DATA
        //EntityData tempData = (EntityData)ScriptableObject.CreateInstance("EntityData");
        //tempData.makeData(oldData);
        GameObject tempObject = Instantiate(tempData.MainBody, vecWhere, new Quaternion());

        tempObject.name = tempData.CreatureName;
        foreach (StructComponentLocation compLocation in tempData.WhereAndWhatsOnMe)
        {
            GameObject tempComponent = Instantiate(allBodyComponents[compLocation.WhatComponent], tempObject.transform);
            tempComponent.transform.localPosition = compLocation.LocalLocation;
        }
        tempObject.GetComponent<EntityControler>().myData = tempData;

    }

    void BrandNewEntity(EntityData tempData, Vector3 vecWhere)
    {
        GameObject tempObject = Instantiate(tempData.MainBody, vecWhere, new Quaternion());
        tempObject.name = tempData.CreatureName;
        MeshFilter tempMeshFilter = tempObject.GetComponent<MeshFilter>();
        Vector3 tMax = tempMeshFilter.mesh.bounds.max;
        Vector3 tMin = tempMeshFilter.mesh.bounds.min;
        for (int i = 0; i < tempData.NumberOfComponents; i++)
        {                                          //NEEDS FIXING
            int CurComponent = tempData.WhatComps[Random.Range(0, tempData.WhatComps.Count)];
            //Debug.Log("What is this:   " + CurComponent + "    Size of bodycomp:   " + allBodyComponents.Count);
            GameObject tempComponent = Instantiate(allBodyComponents[CurComponent], tempObject.transform);
            int whereToGenerate = Random.Range(0, 6); //min inclusive max exclusive
            Vector3 tCompExtent = tempComponent.GetComponent<MeshRenderer>().bounds.extents;
            Vector3 placeComponent = Vector3.zero;
            if (whereToGenerate == 0)
            {
                //TOP
                placeComponent = new Vector3(Random.Range(tMin.x, tMax.x), tMax.y + tCompExtent.y, Random.Range(tMin.z, tMax.z));
            }
            else if (whereToGenerate == 1)
            {
                //BOTTOM
                placeComponent = new Vector3(Random.Range(tMin.x, tMax.x), tMin.y - tCompExtent.y, Random.Range(tMin.z, tMax.z));
            }
            else if (whereToGenerate == 2)
            {
                //RIGHT
                placeComponent = new Vector3(tMax.x + tCompExtent.x, Random.Range(tMin.y, tMax.y), Random.Range(tMin.z, tMax.z));
            }
            else if (whereToGenerate == 3)
            {
                //LEFT
                placeComponent = new Vector3(tMin.x - tCompExtent.x, Random.Range(tMin.y, tMax.y), Random.Range(tMin.z, tMax.z));
            }
            else if (whereToGenerate == 4)
            {
                //Forward
                placeComponent = new Vector3(Random.Range(tMin.x, tMax.x), Random.Range(tMin.y, tMax.y), tMax.z + tCompExtent.z);
            }
            else if (whereToGenerate == 5)
            {
                //BackWard
                placeComponent = new Vector3(Random.Range(tMin.x, tMax.x), Random.Range(tMin.y, tMax.y), tMin.z - tCompExtent.z);
            }
            else
            {
                Debug.LogWarning("This should never have hit this far");
            }
            tempComponent.transform.position = placeComponent + vecWhere; //+ Vector3.up;
            //tempData.AddAStructComponentLocation(tempData.WhatComps[CurComponent], tempComponent.transform.localPosition);
            tempData.AddAStructComponentLocation(CurComponent, tempComponent.transform.localPosition);
        }
        tempObject.GetComponent<EntityControler>().myData = tempData;

        differentEntityList.Add(tempObject);

        //tempObject.transform.position = vecWhere;
        //CombineMeshes(tempObject);
    }

    void CombineTwoOrMoreEntitys(List<EntityData> allData)
    {
        List<int> allComponents = new List<int>();
        List<int> DominantGenes = new List<int>();
        List<int> RecessiveGenes = new List<int>();
        //Figures Out the dominant and recessive genes
        foreach (EntityData tEntity in allData)
        {
            List<int> tempDominant = new List<int>();
            foreach (StructComponentLocation tStruct in tEntity.WhereAndWhatsOnMe)
            {
                tempDominant.Add(tStruct.WhatComponent);
            }
            DominantGenes.AddRange(tempDominant);
            foreach(int tWhatComponent in tEntity.WhatComps)
            {
                if(!tempDominant.Contains(tWhatComponent) && !tempDominant.Contains(tWhatComponent))
                {
                    RecessiveGenes.Add(tWhatComponent);
                }
                allComponents.Add(tWhatComponent);
            }
        }

        float DominantChance = 100f / (float)DominantGenes.Count;
        float RecesiveChance = 100f / (float)RecessiveGenes.Count;
        float ChanceOfRecesiveTrait = 100f / (allBodyComponents.Count / (int)(allBodyComponents.Count / allData.Count)); //Last bit is averge component per creature
        List<StructComponentChance> StructChances = new List<StructComponentChance>();
        List<int> checkedComp = new List<int>();

        //BAD FOR LOOP IN FOR LOOP can maybe be made into a function
        foreach(int DomValue1 in DominantGenes)
        {
            int AmountOFOccurance = 0;
            if (!checkedComp.Contains(DomValue1))
            {
                foreach (int DomValue2 in DominantGenes)
                {
                    if (DomValue1 == DomValue2)
                    {
                        AmountOFOccurance++;
                    }
                }
                checkedComp.Add(DomValue1);
                StructChances.Add(new StructComponentChance(DomValue1, AmountOFOccurance * DominantChance, true));
            }
        }
        //Addubg
        foreach (int tempInt1 in RecessiveGenes)
        {
            int AmountOFOccurance = 0;
           //bool isDom = false;
            if (!checkedComp.Contains(tempInt1))
            {
                foreach (int tempInt2 in RecessiveGenes)
                {
                    if (tempInt1 == tempInt2)
                    {
                        AmountOFOccurance++;
                    }
                }
                checkedComp.Add(tempInt1);
                StructChances.Add(new StructComponentChance(tempInt1, AmountOFOccurance * RecesiveChance, false));
            }
        }

        //foreach (StructComponentChance tempChance in StructChances)
        //{
            //Debug.Log("This Component:   " + tempChance.WhatComponent + "    the Chance:    " + tempChance.Chance +  "   Dom or Not:   " + tempChance.IsDommanent);
        //}
        int averge = 0;
        foreach (EntityData tempData in allData)
        {
            averge += tempData.NumberOfComponents;
        }
        averge /=  allData.Count;



        string name1 = "FIRST MUTANT";
        GameObject mainBody1 = allData[Random.Range(0, allData.Count)].MainBody; //JUST Grabs one of the random modays 
        int numberOfComponents1 = averge;
        List<int> testList1 = new List<int>();
        for (int i = 0; i < averge; i++)
        {
            float whatChances = Random.Range(0f,100f);
            if (ChanceOfRecesiveTrait < whatChances)
            {
                //Dominate chance
                testList1.Add(Probabilty(StructChances , true));
            }
            else
            {
                //Recessive chance
                testList1.Add(Probabilty(StructChances, false));
            }
        }
        EntityData testData = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData.makeData(name1, mainBody1, numberOfComponents1, testList1);
        string result = "";
        foreach (var item in testData.WhatComps)
        {
            result += item.ToString() + ", ";
        }

        Debug.Log("array of components: " + result);
        //BrandNewEntity(testData, new Vector3(10f,3f,10f));
        StartCoroutine(EditEntityMode(testData));
    }

    IEnumerator EditEntityMode(EntityData eData)
    {
        Text WhatSelection = tempUI.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text TextHowManyLeft = tempUI.transform.GetChild(1).gameObject.GetComponent<Text>();
        int howManyPlacesLeft = eData.NumberOfComponents;
        //Debug.Log(howManyPlacesLeft);
        for(int x = 0; x < eData.WhatComps.Count; x++)
        {
            Instantiate(tempImagePrefab, tempUI.transform).GetComponent<Image>().sprite = allSprites[eData.WhatComps[x]];
        }

        GameObject CurrentEditor = Instantiate(eData.MainBody, TestSpawnLocation.position, new Quaternion());
        float rayLength = 15.0f;
        RaycastHit hit;
        float posOrNeg = 0;
        while (true)
        {
            posOrNeg += Input.mouseScrollDelta.y;
            if(posOrNeg > 0)
            {
                posOrNeg = 0;
                whatValueSelection++;
                if (whatValueSelection > eData.WhatComps.Count - 1)
                {
                    whatValueSelection = 0;
                }
            }
            else if (posOrNeg < 0)
            {
                posOrNeg = 0;
                whatValueSelection--;
                if(whatValueSelection < 0)
                {
                    whatValueSelection = eData.WhatComps.Count - 1;
                }
            }
            WhatSelection.text = whatValueSelection + "";
            TextHowManyLeft.text = TextHowManyLeft.text.Substring(0, TextHowManyLeft.text.IndexOf(":") + 1) + " " + howManyPlacesLeft;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, rayLength))
            {
                if (hit.collider != null)
                {                                                                      //Function Goes here

                    Instantiate(allBodyComponents[eData.WhatComps[whatValueSelection]], PlaceCorectly(hit, CurrentEditor, allBodyComponents[eData.WhatComps[whatValueSelection]]), new Quaternion(), hit.collider.gameObject.transform);

                    eData.WhereAndWhatsOnMe.Add(new StructComponentLocation(eData.WhatComps[whatValueSelection], hit.point));
                    howManyPlacesLeft -= 1;
                    if (howManyPlacesLeft < 0)
                    {
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(.00001f);
        }
        yield return null;
    }

    public Vector3 PlaceCorectly(RaycastHit hit, GameObject tParent, GameObject tChild)
    {
        MeshFilter tempMeshFilter = tParent.GetComponent<MeshFilter>();
        Vector3 tMax = tempMeshFilter.mesh.bounds.max;
        Vector3 tMin = tempMeshFilter.mesh.bounds.min;

        Vector3 tCompExtent =  tChild.GetComponent<MeshRenderer>().bounds.extents;

        if (tMax.y == tParent.transform.InverseTransformPoint(hit.point).y)
        {
            //TOP
            return hit.point + new Vector3(0, tCompExtent.y, 0);
        }
        else if (tMin.y == tParent.transform.InverseTransformPoint(hit.point).y)
        {
            //BOTTOM
            return hit.point - new Vector3(0, tCompExtent.y, 0);
        }
        else if (tMax.x == tParent.transform.InverseTransformPoint(hit.point).x)
        {
            //RIGHT
            return hit.point + new Vector3(tCompExtent.x, 0, 0);
        }
        else if (tMin.x == tParent.transform.InverseTransformPoint(hit.point).x)
        {
            //LEFT
            return hit.point - new Vector3(tCompExtent.x, 0, 0);
        }
        else if (tMax.z == tParent.transform.InverseTransformPoint(hit.point).z)
        {
            //Forward
            return hit.point + new Vector3(0, 0, tCompExtent.z);
        }
        else if (tMin.z == tParent.transform.InverseTransformPoint(hit.point).z)
        {
            //BackWard
             return hit.point - new Vector3(0, 0, tCompExtent.z);
        }
        return new Vector3();
    }

    //Test Functionality
    //recomputes everytime
    public int Probabilty(List<StructComponentChance> scc, bool dom)
    {
        var cumulativeWeight = new List<float>();
        float last = 0;
        foreach (StructComponentChance cur in scc)
        {
            if (cur.IsDommanent == dom)
            {
                last += cur.Chance;
                cumulativeWeight.Add(last);
                //Debug.Log("This is a chance:   " + last);
            }
        }
        float choice = Random.Range(0f,100f);
        int i = 0;
        foreach (StructComponentChance cur in scc)
        {
            if (cur.IsDommanent == dom)
            {
                if (choice <= cumulativeWeight[i])
                {
                    return cur.WhatComponent;
                }
                i++;
            }
        }
        return Probabilty(scc, !dom);
        //return -1;
    }
    
    //This will Increase pefromace and allow us to apply a material to everything
    void CombineMeshes(GameObject tempObject)
    {
        MeshFilter[] meshFilters = tempObject.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for (int mf = 0; mf < meshFilters.Length; mf++)
        {
            combine[mf].mesh = meshFilters[mf].sharedMesh;
            combine[mf].transform = meshFilters[mf].transform.localToWorldMatrix;
            meshFilters[mf].gameObject.SetActive(false);
        }
        tempObject.GetComponent<MeshFilter>().mesh = new Mesh();
        tempObject.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, true,true);
        tempObject.gameObject.SetActive(true);
    }
    

}
