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
    //Transform TestSpawnLocation = transform;
    public GameObject TestBody;
    public List<GameObject> allBodyComponents; //This is just temporary

    //public List<ComponentData> listComponentData;

    public GameObject tempImagePrefab;
    public int whatValueSelection = 0;
    public List<Sprite> allSprites;


    //https://www.raywenderlich.com/3169311-runtime-mesh-manipulation-with-unity
    void Start()
    {
        string name = "Test_1.0";
        GameObject mainBody = TestBody;
        int numberOfComponents = 4;
        List<int> testList = new List<int> { 10, 11, 14, 15, 16, 17, 4 };
        List<ComponentData> listComponentData = new List<ComponentData>();
        foreach (int temp in testList)
        {
            if (allBodyComponents[temp].TryGetComponent<ComponentData>(out ComponentData data))
            {
                listComponentData.Add(data);
            }
            else
            {
                Debug.LogError("No ComponentData");
            }
        }
        List<int> testPlaceList = new List<int>{1, 2, 3};
        List<StructHaveToPlace> ListPlacesNeeded = new List<StructHaveToPlace>();
        bool alreadyExits = false;
        foreach (int temp in testPlaceList)
        {
            if(ListPlacesNeeded.Count > 0)
            {
                alreadyExits = false;
                for (int i = 0; i < ListPlacesNeeded.Count; i++)
                {
                    StructHaveToPlace tempPlace = ListPlacesNeeded[i];
                    if (tempPlace.WhatSide == temp)
                    {
                        tempPlace.HowMany += 1;
                        alreadyExits = true;
                        ListPlacesNeeded[i] = tempPlace;
                        break;
                    }
                }
                if (!alreadyExits)
                {
                    ListPlacesNeeded.Add(new StructHaveToPlace(temp, 1));
                }
            }
            else
            {
                ListPlacesNeeded.Add(new StructHaveToPlace(temp, 1));
            }
        }
        //Debug.Log("what is the length of ListPlacesNeeded:  " + ListPlacesNeeded.Count);

        EntityData testData = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData.makeData(name, mainBody, numberOfComponents, listComponentData, ListPlacesNeeded);
        BrandNewEntity(testData, new Vector3(0f, 1f, -10f));
        CopyOfEntity(testData, new Vector3(0f, 3f, -10f));

        string name1 = "Test_2.0";
        GameObject mainBody1 = TestBody;
        int numberOfComponents1 = 7;
        List<int> testList1 = new List<int> { 10, 11, 0, 1, 15, 15, 16, 18, 8 };
        List<ComponentData> listComponentData1 = new List<ComponentData>();
        foreach (int temp in testList1)
        {
            if (allBodyComponents[temp].TryGetComponent<ComponentData>(out ComponentData data))
            {
                listComponentData1.Add(data);
            }
            else
            {
                Debug.LogError("No ComponentData");
            }
        }

        List<int> testPlaceList1 = new List<int> { 1, 2, 3 };
        List<StructHaveToPlace> ListPlacesNeeded1 = new List<StructHaveToPlace>();
        bool alreadyExits1 = false;
        foreach (int temp in testPlaceList1)
        {
            if (ListPlacesNeeded1.Count > 0)
            {
                alreadyExits1 = false;
                for (int i = 0; i < ListPlacesNeeded1.Count; i++)
                {
                    StructHaveToPlace tempPlace = ListPlacesNeeded1[i];
                    if (tempPlace.WhatSide == temp)
                    {
                        tempPlace.HowMany += 1;
                        alreadyExits1 = true;
                        ListPlacesNeeded1[i] = tempPlace;
                        break;
                    }
                }
                if (!alreadyExits1)
                {
                    ListPlacesNeeded1.Add(new StructHaveToPlace(temp, 1));
                }
            }
            else
            {
                ListPlacesNeeded1.Add(new StructHaveToPlace(temp, 1));
            }
        }

        EntityData testData1 = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData1.makeData(name1, mainBody1, numberOfComponents1, listComponentData1, ListPlacesNeeded1);
        BrandNewEntity(testData1, new Vector3(3f, 1f, -10f));
        CopyOfEntity(testData1, new Vector3(3f, 3f, -10f));

        string name2 = "Test_3.0";
        GameObject mainBody2 = TestBody;
        int numberOfComponents2 = 9;
        List<int> testList2 = new List<int> { 10, 11, 14,14,14,17,17,18,18,16 };
        List<ComponentData> listComponentData2 = new List<ComponentData>();
        foreach (int temp in testList2)
        {
            if (allBodyComponents[temp].TryGetComponent<ComponentData>(out ComponentData data))
            {
                data.WhatComponent = temp;
                listComponentData2.Add(data);
            }
            else
            {
                Debug.LogError("No ComponentData");
            }
        }

        List<int> testPlaceList2 = new List<int> { 1, 2, 3 };
        List<StructHaveToPlace> ListPlacesNeeded2 = new List<StructHaveToPlace>();
        bool alreadyExits2 = false;
        foreach (int temp in testPlaceList2)
        {
            if (ListPlacesNeeded2.Count > 0)
            {
                alreadyExits2 = false;
                for (int i = 0; i < ListPlacesNeeded2.Count; i++)
                {
                    StructHaveToPlace tempPlace = ListPlacesNeeded2[i];
                    if (tempPlace.WhatSide == temp)
                    {
                        tempPlace.HowMany += 1;
                        alreadyExits2 = true;
                        ListPlacesNeeded2[i] = tempPlace;
                        break;
                    }
                }
                if (!alreadyExits2)
                {
                    ListPlacesNeeded2.Add(new StructHaveToPlace(temp, 1));
                }
            }
            else
            {
                ListPlacesNeeded2.Add(new StructHaveToPlace(temp, 1));
            }
        }

        EntityData testData2 = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData2.makeData(name2, mainBody2, numberOfComponents2, listComponentData2, ListPlacesNeeded2);
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
            GameObject tempComponent = Instantiate(allBodyComponents[compLocation.WhatComponentData.WhatComponent], tempObject.transform);
            tempComponent.transform.localPosition = compLocation.LocalLocation;
        }
        tempObject.GetComponent<EntityControler>().myData = tempData;

    }

    void BrandNewEntity(EntityData tempData, Vector3 vecWhere)
    {
        GameObject tempObject = Instantiate(tempData.MainBody, vecWhere, new Quaternion());
        tempObject.name = tempData.CreatureName;
        int howManyPlacesLeft = tempData.NumberOfComponents;
        

        while (true)
        {
            howManyPlacesLeft--;
            newComponentGen(tempObject, tempData,Random.Range(0, tempData.WhatComps.Count), true, vecWhere);
            if (howManyPlacesLeft < 0)
            {
                break;
            }
        }
    }

    int validComponent(EntityData tempData, int testComponent)
    {
        //while (true)
        //{
        ComponentData compData = tempData.WhatComps[testComponent];
        bool requeredPlacesLeft = false;
        foreach (StructHaveToPlace data in tempData.RequiredPlacement)
        {
            if (data.HowMany > data.HowManyPlaced) //&& compData.WhereCanPlace.Contains(data.WhatSide))
            {
                foreach (ComponentData cD in tempData.WhatComps)
                {
                    if (cD.WhereCanPlace.Contains(data.WhatSide))
                    {
                        requeredPlacesLeft = true;
                        break;
                    }
                }
            }
        }


        if (requeredPlacesLeft)
        {
            //HARDCODED for now
            for (int k = 0; k < compData.WhereCanPlace.Count * 3; k++)
            {
                int randomTry = compData.WhereCanPlace[Random.Range(0, compData.WhereCanPlace.Count)];
                for (int i = 0; i < tempData.RequiredPlacement.Count; i++)
                {
                    if (randomTry == tempData.RequiredPlacement[i].WhatSide
                        && tempData.RequiredPlacement[i].HowMany > tempData.RequiredPlacement[i].HowManyPlaced
                        && compData.WhereCanPlace.Contains(tempData.RequiredPlacement[i].WhatSide))
                    {
                        //tempData.RequiredPlacement[i].AddToPlaced();
                        //Debug.Log("what and how many:  " + testComponent + " placed:" + tempData.RequiredPlacement[i].HowManyPlaced);
                        return randomTry;
                    }
                }
            }
            //Debug.Log("Most Likely requered comp is not into dna doesnt exist");
            //return testComponent;
            return validComponent(tempData, Random.Range(0, tempData.WhatComps.Count));
        }
        else
        {
            //Debug.Log("no requered places left:  " + testComponent);
            return testComponent;//componentData.WhereCanPlace[Random.Range(0, componentData.WhereCanPlace.Count)];
        }
        //}
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
                tempDominant.Add(tStruct.WhatComponentData.WhatComponent);
            }
            DominantGenes.AddRange(tempDominant);
            foreach(ComponentData tWhatComponent in tEntity.WhatComps)
            {
                if (!tempDominant.Contains(tWhatComponent.WhatComponent) && !tempDominant.Contains(tWhatComponent.WhatComponent))
                {
                    RecessiveGenes.Add(tWhatComponent.WhatComponent);
                }
                allComponents.Add(tWhatComponent.WhatComponent);
            }
        }

        float DominantChance = 100f / (float)DominantGenes.Count;
        float RecesiveChance = 100f / (float)RecessiveGenes.Count;
        float ChanceOfRecesiveTrait = 100f / (allBodyComponents.Count / (int)(allBodyComponents.Count / allData.Count)); //Last bit is averge component per creature
        List<StructComponentChance> StructChances = new List<StructComponentChance>();
        List<int> checkedComp = new List<int>();

        //BAD FOR LOOP IN FOR LOOP can maybe be made into a function
        foreach (int DomValue1 in DominantGenes)
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
        int averge = 0;
        foreach (EntityData tempData in allData)
        {
            averge += tempData.NumberOfComponents;
        }
        averge /= allData.Count;

        string name1 = "FIRST MUTANT";
        GameObject mainBody1 = allData[Random.Range(0, allData.Count)].MainBody; //JUST Grabs one of the random modays 
        int numberOfComponents1 = averge;
        List<int> testList1 = new List<int>();

        for (int i = 0; i < averge; i++)
        {
            float whatChances = Random.Range(0f, 100f);
            if (ChanceOfRecesiveTrait < whatChances)
            {
                //Dominate chance
                testList1.Add(Probabilty(StructChances, true));
            }
            else
            {
                //Recessive chance
                testList1.Add(Probabilty(StructChances, false));
            }
        }
        //Maybe repeat code
        List<ComponentData> listComponentDataNew = new List<ComponentData>();
        foreach (int temp in testList1)
        {
            if (allBodyComponents[temp].TryGetComponent(out ComponentData data))
            {
                data.WhatComponent = temp;
                listComponentDataNew.Add(data);
            }
            else
            {
                Debug.LogError("No ComponentData");
            }
        }

        //NEEDS ACTUILY CODE TODO
         List<StructHaveToPlace> tempPLACE = allData[Random.Range(0, allData.Count)].RequiredPlacement;

        for(int i = 0; i<tempPLACE.Count;i++)
        {
            StructHaveToPlace tStruct = tempPLACE[i];
            tStruct.HowManyPlaced = 0;
            tempPLACE[i] = tStruct;
        }

        EntityData testData = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData.makeData(name1, mainBody1, numberOfComponents1, listComponentDataNew, tempPLACE);
        Debug.Log(tempPLACE[0].HowMany + " this is how many");
        string result = "";
        foreach (var item in testData.WhatComps)
        {
            result += item.ToString() + ", ";
        }

        Debug.Log("array of components: " + result);
        //BrandNewEntity(testData, new Vector3(10f,3f,10f));


        foreach(StructHaveToPlace te in tempPLACE)
        {
            Debug.Log(te.WhatSide + "     " + te.HowMany + "    " + te.HowManyPlaced);
        }


        StartCoroutine(EditEntityMode(testData));
    }

    int GenerateWhere(EntityData eData, ComponentData componentData)
    {
        /* 
         * Maybe not
        bool requeredPlacesLeft = eData.RequiredPlacement.TrueForAll(place =>
        {
            if (place.HowMany > place.HowManyPlaced)
            {
                return true;
            }
            else
            {
                return false;
            }
        });
        */
        bool requeredPlacesLeft = false;
        foreach (StructHaveToPlace data in eData.RequiredPlacement)
        {
            //Debug.Log(data.HowMany + " Greater then " + data.HowManyPlaced);
            if (data.HowMany > data.HowManyPlaced && componentData.WhereCanPlace.Contains(data.WhatSide))
            {
                requeredPlacesLeft = true;
                //Debug.Log("GO GO GO Go");
                break;
            }
        }

        if (requeredPlacesLeft)
        {
            while (true)
            {
                int randomTry = componentData.WhereCanPlace[Random.Range(0, componentData.WhereCanPlace.Count)];
                for (int i = 0; i < eData.RequiredPlacement.Count; i++)
                {
                    if (randomTry == eData.RequiredPlacement[i].WhatSide 
                        && eData.RequiredPlacement[i].HowMany > eData.RequiredPlacement[i].HowManyPlaced 
                        && componentData.WhereCanPlace.Contains(eData.RequiredPlacement[i].WhatSide))
                    {
                        StructHaveToPlace tempStruct = eData.RequiredPlacement[i];
                        tempStruct.AddToPlaced();
                        eData.RequiredPlacement[i] = tempStruct;
                        Debug.Log("Should happen like now");
                        return randomTry;
                    }
                }
            }
        }
        else
        {
            //Debug.Log("Does this happen");
            return componentData.WhereCanPlace[Random.Range(0, componentData.WhereCanPlace.Count)];
            //return -1;
        }
    }

    private GameObject newComponentGen(GameObject mainBody, EntityData tempData, int WhitchComponentSpawn, bool isTranslate, Vector3 vecWhere)
    {

        ComponentData componentData = tempData.WhatComps[validComponent(tempData, WhitchComponentSpawn)];//WhitchComponentSpawn];
        int whereToGenerate = GenerateWhere(tempData, componentData); //componentData.WhereCanPlace[Random.Range(0, componentData.WhereCanPlace.Count)]; //min inclusive max exclusive


        GameObject CurComponent = componentData.gameObject;
        GameObject tempComponent = Instantiate(CurComponent, mainBody.transform);

        //int whereToGenerate = GenerateWhere(tempData, componentData); //componentData.WhereCanPlace[Random.Range(0, componentData.WhereCanPlace.Count)]; //min inclusive max exclusive

        MeshFilter tempMeshFilter = mainBody.GetComponent<MeshFilter>();
        Vector3 tMax = tempMeshFilter.mesh.bounds.max;
        Vector3 tMin = tempMeshFilter.mesh.bounds.min;

        //Vector3 tCompExtent = tempComponent.GetComponent<MeshRenderer>().bounds.extents;
        Vector3 tCompExtent = Vector3.zero;// tempComponent.GetComponent<MeshRenderer>().bounds.extents;
        if (tempComponent.TryGetComponent<MeshRenderer>(out MeshRenderer tMeshRender))
        {
            tCompExtent = tMeshRender.bounds.extents;
        }
        else if (tempComponent.transform.GetChild(0).transform.GetChild(0).TryGetComponent<SkinnedMeshRenderer>(out SkinnedMeshRenderer tSkinnedRender))
        {
            //tCompExtent = 1.6f * tSkinnedRender.bounds.extents;
            tCompExtent = tempComponent.GetComponent<BoxCollider>().bounds.extents * 1.9f;
        }
        else
        {
            throw new System.Exception("No Mesh Found");
        }


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
            placeComponent = new Vector3(tMax.x + tCompExtent.x - .05f, Random.Range(tMin.y, tMax.y), Random.Range(tMin.z, tMax.z));
        }
        else if (whereToGenerate == 3)
        {
            //LEFT                                             this is for arms
            placeComponent = new Vector3(tMin.x - tCompExtent.x + .05f, Random.Range(tMin.y, tMax.y), Random.Range(tMin.z, tMax.z));
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
            Debug.LogWarning("This should never have hit this far " + whereToGenerate + " This");
        }
        tempComponent.SetActive(false);
        if (isTranslate)
        {
            tempComponent.transform.position = placeComponent + vecWhere; //+ Vector3.up;
        }
        else
        {
            tempComponent.transform.position = placeComponent + transform.position;
        }
        //tempComponent.SetActive(false);
        tempData.AddAStructComponentLocation(componentData, tempComponent.transform.localPosition);
        return tempComponent;
        //return placeComponent;

        //mainBody.GetComponent<EntityControler>().myData = tempData;

        //differentEntityList.Add(mainBody);

        //tempComponent.transform.position = vecWhere;
        //CombineMeshes(tempObject);
    }
    private Vector3 findLocationForCamera(Vector3 componentPosition)
    {
        /*
        int radius = 10;
        Vector3 center = transform.position;
        Vector3 target = transform.position - componentPosition;
        target.Scale(new Vector3(20, 20, 20));
        Vector3 vector = new Vector3(target.x - center.x, target.y - center.y, target.z - center.z);
        var length = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2));
        Vector3 normal = new Vector3(vector.x / length, vector.y / length, vector.z / length);
        Vector3 result = new Vector3(center.x + (normal.x * radius), center.y + (normal.y * radius), center.z + (normal.z * radius));
        return result;
        //findCircleInteresction(new Point2D(0, 0), 15, new Point2D(50, 30));
        
        /*


        int radius = 10;
        Vector3 center = transform.position;
        Vector3 target = componentPosition - transform.position;//target Works
        target.Scale(new Vector3(20, 20, 20));
        testVector = target;



        float targetMinusCenterX = target.x - center.x;
        float targetMinusCenterY = target.y - center.y;
        float targetMinusCenterZ = target.z - center.z;
        float a = (Mathf.Pow((targetMinusCenterX), 2) + Mathf.Pow((targetMinusCenterY), 2) + Mathf.Pow((targetMinusCenterZ), 2));
        float b = 2 * ((targetMinusCenterX * (center.x - center.x)) + (targetMinusCenterY * (center.y - center.y)) + (targetMinusCenterZ * (center.z - center.z)));
        float c = 0 - Mathf.Pow(radius, 2);
        //float answer = 0;
        float answer1 = 0;
        float answer2 = 0;
        if ((Mathf.Pow(b, 2) > 4 * a * c))
        {
            /*
            //answer = (2 * c) / ((-b) + Mathf.Sqrt((b * b) - (4 * a * c)));
            float sqrtpart = (b * b) - (4 * a * c);
            answer1 = ((-1) * b + Mathf.Sqrt(sqrtpart)) / (2 * a);
            answer2 = ((-1) * b - Mathf.Sqrt(sqrtpart)) / (2 * a);
            //Debug.Log("t: " + answer1 + "  " + answer2);
            */
        // }
        /*
            else
            {
                Debug.LogError("This should never happen  t:" + answer1 + "  " + answer2);
                throw new System.Exception("bad values");
            }
            /*
            Vector3 Vec1 = new Vector3(targetMinusCenterX * answer1 + center.x,
                                   targetMinusCenterY * answer1 + center.y,
                                   targetMinusCenterZ * answer1 + center.z);
            Vector3 Vec2 = new Vector3(targetMinusCenterX * answer2 + center.x,
                                   targetMinusCenterY * answer2 + center.y,
                                   targetMinusCenterZ * answer2 + center.z);
            */
        /*
            if (Vector3.Distance(componentPosition, Vec1) < Vector3.Distance(componentPosition, Vec2))
            {
                return Vec1;
            }
            else // 2 closer
            {
                return Vec2;
            }
            */

        int radius = 10;
        Vector3 center = transform.position;
        Vector3 target = componentPosition - transform.position;//target Works
        target.Scale(new Vector3(20, 20, 20));
        testVector = target;
        Vector3 direction = transform.TransformDirection(target);
        //function intersectRayWithSphere(center, radius,
        //                            origin, direction,
        //                            intersection)
        //{
        // Solve |O + t D - C|^2 = R^2
        //       t^2 |D|^2 + 2 t < D, O - C > + |O - C|^2 - R^2 = 0
        Vector3 OC; //intersection; // Use the output parameter as temporary workspace

        OC.x = center.x - center.x;
        OC.y = center.y - center.y;
        OC.z = center.z - center.z;

        // Solve the quadratic equation a t^2 + 2 t b + c = 0
        // var a = squaredLength(direction);
        //var b = dotProduct(direction, OC);
        //var c = squaredLength(OC) - radius * radius;
        float a = Vector3.Dot(direction, direction);
        float b = Vector3.Dot(direction, OC);
        float c = Vector3.Dot(OC, OC) - radius * radius;
        float delta = b * b - a * c;

        if (delta < 0) // No solution
        {
            Debug.LogError("This should never happen  delta: " + delta);
            throw new System.Exception("No solution");
        }

        // One or two solutions, take the closest (positive) intersection
        var sqrtDelta = Mathf.Sqrt(delta);

        // a >= 0
        var tMin = (-b - sqrtDelta) / a;
        var tMax = (-b + sqrtDelta) / a;

        if (tMax < 0) // All intersection points are behind the origin of the ray
        {
            Debug.LogError("This should never happen  tMax: " + tMax);
            throw new System.Exception("Behind Ray");
        }

        // tMax >= 0
        var t = tMin >= 0 ? tMin : tMax;

        return new Vector3(center.x + t * direction.x, center.y + t * direction.y, center.z + t * direction.z);

    }

    public Vector3 testVector;
    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(testVector) * 15;
        Gizmos.DrawRay(transform.position, direction);
    }

    IEnumerator EditEntityMode(EntityData eData)
    {
        int interpolationFramesCount = 800;
        int elapsedFrames = 0;
        bool first = true;
        Vector3 newLocation = transform.position + (Random.onUnitSphere * 10); ;
        Vector3 oldLocation = Camera.main.transform.position;

        Text WhatSelection = tempUI.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text TextHowManyLeft = tempUI.transform.GetChild(1).gameObject.GetComponent<Text>();
        int howManyPlacesLeft = eData.NumberOfComponents;
        //Debug.Log(howManyPlacesLeft);
        for (int x = 0; x < eData.WhatComps.Count; x++)
        {
            Instantiate(tempImagePrefab, tempUI.transform).GetComponent<Image>().sprite = allSprites[eData.WhatComps[x].WhatComponent];
        }

        GameObject CurrentEditor = Instantiate(eData.MainBody, transform.position, new Quaternion());
        float rayLength = 15.0f;
        RaycastHit hit;
        bool wait = false;
        GameObject currentComponent = null;

        while (true)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
            Vector3 interpolatedPosition = Vector3.Lerp(oldLocation, newLocation, interpolationRatio);
            if (interpolatedPosition.Equals(newLocation) || first)
            {
                wait = true;
                first = false;
                whatValueSelection = Random.Range(0, eData.WhatComps.Count - 1);
                WhatSelection.text = whatValueSelection + "";
                TextHowManyLeft.text = TextHowManyLeft.text.Substring(0, TextHowManyLeft.text.IndexOf(":") + 1) + " " + howManyPlacesLeft;

                //newLocation = transform.position + (Random.onUnitSphere * 10);
                if (currentComponent != null)
                {
                    currentComponent.SetActive(true);
                    yield return new WaitForSeconds(.1f);
                }
                currentComponent = newComponentGen(CurrentEditor, eData, whatValueSelection, false, Vector3.zero);
                newLocation = findLocationForCamera(currentComponent.transform.position);

                oldLocation = Camera.main.transform.position;
            }
            else
            {
                Camera.main.transform.position = interpolatedPosition;
                Camera.main.transform.LookAt(transform.position);
            }
            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
            //Moved up
            //whatValueSelection = Random.Range(0, eData.WhatComps.Count - 1);
            //WhatSelection.text = whatValueSelection + "";
            //TextHowManyLeft.text = TextHowManyLeft.text.Substring(0, TextHowManyLeft.text.IndexOf(":") + 1) + " " + howManyPlacesLeft;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out hit, rayLength))
            {
                if (hit.collider != null && wait == true)
                {
                    yield return new WaitForSeconds(.1f);
                    wait = false;
                    //Instantiate(allBodyComponents[eData.WhatComps[whatValueSelection].WhatComponent], PlaceCorectly(hit, CurrentEditor, allBodyComponents[eData.WhatComps[whatValueSelection].WhatComponent]), new Quaternion(), hit.collider.gameObject.transform);
                    //currentComponent.SetActive(true);
                    yield return new WaitForSeconds(.1f);
                    eData.WhereAndWhatsOnMe.Add(new StructComponentLocation(eData.WhatComps[whatValueSelection], hit.point));
                    howManyPlacesLeft -= 1;
                    if (howManyPlacesLeft < 0)
                    {
                        break;
                    }
                }
                else
                {
                    //POOF animation
                    //error sound clip
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

        Vector3 tCompExtent = tChild.GetComponent<MeshRenderer>().bounds.extents;

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
        float choice = Random.Range(0f, 100f);
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
        tempObject.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, true, true);
        tempObject.gameObject.SetActive(true);
    }


    /*
     * OLD BRAND NEW ENITY
        MeshFilter tempMeshFilter = tempObject.GetComponent<MeshFilter>();
        Vector3 tMax = tempMeshFilter.mesh.bounds.max;
        Vector3 tMin = tempMeshFilter.mesh.bounds.min;
        for (int i = 0; i < tempData.NumberOfComponents; i++)
        {                                          //NEEDS FIXING
            ComponentData componentData = tempData.WhatComps[Random.Range(0, tempData.WhatComps.Count)];
            GameObject CurComponent = componentData.gameObject;
            GameObject tempComponent = Instantiate(CurComponent, tempObject.transform);// allBodyComponents[CurComponent], tempObject.transform);
            //Debug.Log(tempData.WhatComps.Count);
            //Debug.Log(componentData.WhereCanPlace.Count);
            int whereToGenerate = componentData.WhereCanPlace[Random.Range(0, componentData.WhereCanPlace.Count)]; //min inclusive max exclusive

            Vector3 tCompExtent = Vector3.zero;// tempComponent.GetComponent<MeshRenderer>().bounds.extents;
            if(tempComponent.TryGetComponent<MeshRenderer>(out MeshRenderer tMeshRender))
            {
                tCompExtent = tMeshRender.bounds.extents;
            }
            else if(tempComponent.transform.GetChild(0).transform.GetChild(0).TryGetComponent<SkinnedMeshRenderer>(out SkinnedMeshRenderer tSkinnedRender))
            {
                //why is the mesh of the skinned render different
                //maybe for both???
                //tCompExtent = (1.85f * tempComponent.GetComponent<BoxCollider>().bounds.extents) ;//
                tCompExtent = 1.6f * tSkinnedRender.bounds.extents;
            }
            else
            {
                throw new System.Exception("No Mesh Found");
            }

            Vector3 placeComponent = Vector3.zero;
            //Debug.Log(tempData.WhatComps.Count);
            //Debug.Log("here");
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
            tempData.AddAStructComponentLocation(componentData, tempComponent.transform.localPosition);
        }
        tempObject.GetComponent<EntityControler>().myData = tempData;

        differentEntityList.Add(tempObject);

        //tempObject.transform.position = vecWhere;
        //CombineMeshes(tempObject);
        */
}
