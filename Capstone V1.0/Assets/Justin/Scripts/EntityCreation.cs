using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

//Singlton pattern
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
    [SerializeField] Material BaseCOLOR;
    [SerializeField] Material SecondCOLOR;

    public GameObject tempUI;
    public GameObject TestBody;
    public List<GameObject> allBodyComponents;
    public List<GameObject> ALLBODYS;
    public EntityData onDeckData;
    public GameObject tempImagePrefab;
    public int whatValueSelection = 0;
    public List<Sprite> allSprites;

    [SerializeField] private GameObject spawnPoints;


    public List<EntityData> eLists;

    #region DefineCreatures
    private void Start()
    {
        for (int i = 0; i < allBodyComponents.Count; i++)
        {
            allBodyComponents[i].GetComponent<ComponentData>().WhatComponent = i;
        }

        string name = "First_1.0";
        GameObject mainBody = ALLBODYS[0];
        int numberOfComponents = 5;
        List<int> WhatComponentsList = new List<int> { 12, 13, 14, 15, 0, 1, 2, 5, 6, 7, 11, 3, 7, 6, 8 };
        List<int> testPlaceList = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData = Creation(name, mainBody, numberOfComponents, WhatComponentsList, testPlaceList, true);

        string name1 = "Second_2.0";
        GameObject mainBody1 = ALLBODYS[1];
        int numberOfComponents1 = 8;
        List<int> WhatComponentsList1 = new List<int> { 12, 13, 14, 15, 12, 13, 14, 15, 1, 2, 3, 6, 4, 7, 8, 5, 10, 11, 0, 1, 2, 5, 6, 7, 11, 3, 7, 6, 8 };
        List<int> testPlaceList1 = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData1 = Creation(name1, mainBody1, numberOfComponents1, WhatComponentsList1, testPlaceList1, true);

        string name2 = "Third_3.0";
        GameObject mainBody2 = ALLBODYS[2];
        int numberOfComponents2 = 7;
        List<int> WhatComponentsList2 = new List<int> { 0, 12, 13, 14, 15, 11, 11, 1, 2, 3, 2, 6, 8, 4, 5, 8, 9, 10, 1, 2, 3, 6, 4, 7, 8, 5, 10, 11 };
        List<int> PlaceList = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData2 = Creation(name2, mainBody2, numberOfComponents2, WhatComponentsList2, PlaceList, true);

        string name3 = "Fourth_4.0";
        GameObject mainBody3 = ALLBODYS[3];
        int numberOfComponents3 = 8;
        List<int> WhatComponentsList3 = new List<int> { 12, 13, 14, 15, 0, 0, 0, 1, 5, 6, 7, 8, 7, 4, 11, 10, 9, 9, 1, 2, 3, 6, 4, 7, 8, 5, 10, 11 };
        List<int> PlaceList1 = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData3 = Creation(name3, mainBody3, numberOfComponents3, WhatComponentsList3, PlaceList1, true);

        string name4 = "Fith.5";
        GameObject mainBody4 = ALLBODYS[Random.Range(0, ALLBODYS.Count)];
        int numberOfComponents4 = 9;
        List<int> WhatComponentsList4 = new List<int> { 12, 13, 14, 15, 0, 0, 0, 1, 5, 6, 7, 8, 7, 4, 11, 10, 9, 9, 1, 2, 3, 6, 4, 7, 8, 5, 10, 11, 12, 13, 14, 15, 12, 13, 14, 15, 1, 2, 3, 6, 4, 7, 8, 5, 10, 11, 0, 1, 2, 5, 6, 7, 11, 3, 7, 6, 8 };
        List<int> PlaceList4 = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData4 = Creation(name4, mainBody4, numberOfComponents4, WhatComponentsList4, PlaceList4, true);

        string name5 = "six.6";
        GameObject mainBody5 = ALLBODYS[Random.Range(0, ALLBODYS.Count)];
        int numberOfComponents5 = 6;
        List<int> WhatComponentsList5 = new List<int> { 12, 13, 14, 15, 0, 0, 0, 1, 5, 6, 4, 7, 8, 5, 10, 11, 12, 13, 14, 15, 12, 13, 14, 15, 1, 2, 3, 6, 4, 7, 8, 5, 10, 11, 0, 1, 2, 5, 6, 7, 11, 3, 7, 6, 8 };
        List<int> PlaceList5 = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData5 = Creation(name5, mainBody5, numberOfComponents5, WhatComponentsList5, PlaceList5, true);


        eLists = new List<EntityData>();
        eLists.Add(testData);
        eLists.Add(testData1);
        eLists.Add(CombineTwoOrMoreEntitys(eLists, false));
        eLists.Add(testData2);
        eLists.Add(testData3);
        eLists.Add(CombineTwoOrMoreEntitys(eLists, false));
        eLists.Add(testData4);
        eLists.Add(testData5);
        eLists.Add(CombineTwoOrMoreEntitys(eLists, false));
        eLists.Add(CombineTwoOrMoreEntitys(eLists, false));
        eLists.Add(CombineTwoOrMoreEntitys(eLists, false));
        eLists.Add(CombineTwoOrMoreEntitys(eLists, false));
        eLists.Add(CombineTwoOrMoreEntitys(eLists, false));

        foreach (Transform childSpawn in spawnPoints.transform)
        {
            int whatCreature = Random.Range(0, eLists.Count);
            for (int i = 0; i < Random.Range(4, 11); i++)
            {
                OnFinshMonster(eLists[whatCreature], childSpawn.position + new Vector3(Random.Range(1f, 2f), 0f, Random.Range(1f, 2f)));
            }
        }
    }

    //Called when trigger for new creatures
    public void StartCreationTest()
    {
        string name = "Test_1.0";
        GameObject mainBody = ALLBODYS[Random.Range(0, ALLBODYS.Count)];
        int numberOfComponents = 7;
        List<int> WhatComponentsList = new List<int> { 0, 12, 13, 14, 15, 11, 11, 1, 2, 3, 2, 6, 8, 4, 5, 8, 9, 10, 1, 2, 3, 6, 4, 7, 8, 5, 10, 11 };
        List<int> PlaceList = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData = Creation(name, mainBody, numberOfComponents, WhatComponentsList, PlaceList, true);

        string name1 = "Test_2.0";
        GameObject mainBody1 = ALLBODYS[Random.Range(0, ALLBODYS.Count)];
        int numberOfComponents1 = 8;
        List<int> WhatComponentsList1 = new List<int> { 12, 13, 14, 15, 0, 0, 0, 1, 5, 6, 7, 8, 7, 4, 11, 10, 9, 9, 1, 2, 3, 6, 4, 7, 8, 5, 10, 11 };
        List<int> PlaceList1 = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData1 = Creation(name1, mainBody1, numberOfComponents1, WhatComponentsList1, PlaceList1, true);

        string name2 = "Test_3.0";
        GameObject mainBody2 = ALLBODYS[Random.Range(0, ALLBODYS.Count)];
        int numberOfComponents2 = 9;
        List<int> WhatComponentsList2 = new List<int> { 12, 13, 14, 15, 10, 11, 0, 1, 8, 10, 11, 4, 2, 3, 4, 2, 3, 7, 8, 9 };
        List<int> PlaceList2 = new List<int> { 0, 1, 2, 3, 2, 3 };
        EntityData testData2 = Creation(name2, mainBody2, numberOfComponents2, WhatComponentsList2, PlaceList2, true);

        List<EntityData> testEntitys = new List<EntityData>();
        testEntitys.Add(testData);
        testEntitys.Add(testData);
        testEntitys.Add(testData1);
        testEntitys.Add(testData2);

        CombineTwoOrMoreEntitys(testEntitys, true);
    }

    #endregion

    #region MakeCreatures

    //Sets up the list, arrays, structs so creatues can be made. 
    EntityData Creation(string name, GameObject mainBody, int numberOfComponents, List<int> WhatComponentsList, List<int> PlaceList, bool runWhileLoop)
    {
        List<ComponentData> listComponentData = new List<ComponentData>();
        foreach (int temp in WhatComponentsList)
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
        List<StructHaveToPlace> ListPlacesNeeded = new List<StructHaveToPlace>();
        bool alreadyExits = false;
        foreach (int temp in PlaceList)
        {
            if (ListPlacesNeeded.Count > 0)
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
        //Debug.Log(ListPlacesNeeded.Count);
        EntityData testData = (EntityData)ScriptableObject.CreateInstance("EntityData");
        testData.makeData(name, mainBody, numberOfComponents, listComponentData, ListPlacesNeeded);
        BrandNewEntity(testData, new Vector3(0f, 1f, -10f), runWhileLoop);
        return testData;
    }

    //Actuily makes the creatures.
    public void OnFinshMonster(EntityData tData, Vector3 location)
    {
        GameObject newMonster;
        if (tData == null)
        {
            newMonster = CopyOfEntity(onDeckData, location);
        }
        else
        {
            newMonster = CopyOfEntity(tData, location);
        }
        newMonster.GetComponent<EntityControler>().addAi();
        newMonster.GetComponent<EntityControler>().whatNewColor();
        newMonster.GetComponent<EntityControler>().finshItUp();
    }

    public GameObject OnFinshDisplay(EntityData tData, Vector3 location)
    {
        GameObject newMonster;
        newMonster = CopyOfEntity(tData, location);
        // newMonster.GetComponent<EntityControler>().addAi();
        newMonster.GetComponent<EntityControler>().whatNewColor();
        newMonster.GetComponent<EntityControler>().finshItUp();

        return newMonster;
    }

    public GameObject CopyOfEntity(EntityData tempData, Vector3 vecWhere)
    {
        GameObject tempObject = Instantiate(tempData.MainBody, vecWhere, new Quaternion());
        tempObject.name = tempData.CreatureName;
        Transform childTrans = null;
        foreach (Transform trans in tempObject.transform.GetComponentsInChildren<Transform>())
        {
            //Debug.Log(trans.name);
            if (trans.name == "ALLBODYPARTS")
            {
                childTrans = trans;
            }
        }
        foreach (StructComponentLocation compLocation in tempData.WhereAndWhatsOnMe)
        {
            GameObject tempComponent = Instantiate(allBodyComponents[compLocation.WhatComponentData.WhatComponent], tempObject.transform);
            tempComponent.transform.localPosition = compLocation.LocalLocation;
            tempComponent.transform.parent = childTrans;
        }
        tempObject.GetComponent<EntityControler>().myData = tempData;
        tempObject.transform.parent = gameObject.transform;
        return tempObject;
    }

    void BrandNewEntity(EntityData tempData, Vector3 vecWhere, bool runWhileLoop)
    {
        string[] FirstNames = { "Concoction ", "Hangdog ", "Bombastic ", "Cheesecake ", "Corkscrew ",
            "Jawbreaker ", "Kerfuffle ", "Quaff ", "Spoon ", "Webinar ", "Lambasted ", "Nomenclature ",
            "Syzygy ", "Preposterous ", "Defenestrate ", "Sialoquent ", "Bumpkin ", "Moocher ", "Dilemma ",
            "Highfalutin ", "Scalawag ", "Majordomo ", "Hurlyburly ", "Topsyturvy ", "Taradiddle ",
            "Gobsmacked ", "Cattitude ", "Scofflaw ", "Flummery ", "Wordsmith ", "Nambypamby ", "Tubthumper ",
            "Googolplex ", "Cornucopia ", "Derriere ", "Flippant ", "Bifurcate ", "Headlong ","Swashbuckler " ,"Freewheeling "};
        string[] LastNames = { "Bugaboo", "Zeugma", "Tomfoolery","Corkscrew","Pratfall"," Schmutz",
            "Persnickety","Kelvin","Hippocampus","Egghead","Scofflaw","Thingamabob","Flume","Lampoon",
            "Tureen","Loggerhead","Netiquette","Doldrums","Fantods","Eleventeen","Rumpa","Mumpsimus",
            "Firkin","Armdump","Footloose","Rugrat","Lisp","Zygote","Eggcorn", "Bulgur",
        "Toothsome","Hijinks","Balderdash","Mojo","Nidifugous","Wabbit","Behoove", "Foolscap"};
        string EntityName = FirstNames[Random.Range(0, FirstNames.Length)] + LastNames[Random.Range(0, LastNames.Length)];
        tempData.CreatureName = EntityName;
        GameObject tempObject = Instantiate(tempData.MainBody, vecWhere, new Quaternion());
        tempObject.name = tempData.CreatureName;
        int howManyPlacesLeft = tempData.NumberOfComponents;
        RandomColor(tempData);

        while (runWhileLoop)
        {
            howManyPlacesLeft--;
            newComponentGen(tempObject, tempData, Random.Range(0, tempData.WhatComps.Count), true, vecWhere);
            if (howManyPlacesLeft < 0)
            {
                break;
            }
        }
        Destroy(tempObject);
    }

    private GameObject newComponentGen(GameObject mainBody, EntityData tempData, int WhitchComponentSpawn, bool isTranslate, Vector3 vecWhere)
    {
        int validNum = validComponent(tempData, WhitchComponentSpawn);
        ComponentData componentData = tempData.WhatComps[validNum];//WhitchComponentSpawn];
        //Debug.Log("validNum " + validNum+ " what component " + componentData.componentName);
        int whereToGenerate = GenerateWhere(tempData, componentData); //componentData.WhereCanPlace[Random.Range(0, componentData.WhereCanPlace.Count)]; //min inclusive max exclusive

        GameObject CurComponent = componentData.gameObject;
        GameObject tempComponent = Instantiate(CurComponent, mainBody.transform);
        //int whereToGenerate = GenerateWhere(tempData, componentData); //componentData.WhereCanPlace[Random.Range(0, componentData.WhereCanPlace.Count)]; //min inclusive max exclusive
        Vector3 tMax, tMin;
        Renderer rend = mainBody.GetComponentInChildren<Renderer>();
        tMax = rend.bounds.max;
        tMin = rend.bounds.min;
        Vector3 placeComponent = Vector3.zero;
        if (whereToGenerate == 0)
        {
            //TOP
            //placeComponent = new Vector3(Random.Range(tMin.x, tMax.x), tMax.y + tCompExtent.y, Random.Range(tMin.z, tMax.z));
            placeComponent = new Vector3(mainBody.transform.position.x, tMax.y, mainBody.transform.position.z);
        }
        else if (whereToGenerate == 1)
        {
            //BOTTOM
            placeComponent = new Vector3(Random.Range(tMin.x, tMax.x), tMin.y / 2, Random.Range(tMin.z, tMax.z));
        }
        else if (whereToGenerate == 2)
        {
            //RIGHT
            placeComponent = new Vector3(tMax.x, Random.Range(tMin.y, tMax.y), Random.Range(tMin.z, tMax.z));
        }
        else if (whereToGenerate == 3)
        {
            //LEFT                                             this is for arms
            placeComponent = new Vector3(tMin.x, Random.Range(tMin.y, tMax.y), Random.Range(tMin.z, tMax.z));
        }
        else if (whereToGenerate == 4)
        {
            //Forward
            placeComponent = new Vector3(Random.Range(tMin.x, tMax.x), Random.Range(tMin.y, tMax.y), tMax.z);
        }
        else if (whereToGenerate == 5)
        {
            //BackWard
            placeComponent = new Vector3(Random.Range(tMin.x, tMax.x), Random.Range(tMin.y, tMax.y), tMin.z);
        }
        else
        {
            Debug.LogWarning("This should never have hit this far " + whereToGenerate + " This");
        }
        tempComponent.SetActive(false);
        tempComponent.transform.position = placeComponent;// + vecWhere; //+ Vector3.up;
        MoveMeshesAndScale(mainBody, tempComponent);
        tempData.AddAStructComponentLocation(componentData, tempComponent.transform.localPosition);
        return tempComponent;
    }

    #endregion

    #region CombineAndCreate
    public EntityData CombineTwoOrMoreEntitys(List<EntityData> allData, bool runCreation)
    {
        List<int> allComponents = new List<int>();
        List<int> DominantGenes = new List<int>();
        List<int> RecessiveGenes = new List<int>();
        //Figures Out the dominant and recessive genes
        foreach (EntityData tEntity in allData)
        {
            foreach (ComponentData tWhatComponent in tEntity.WhatComps)
            {
                RecessiveGenes.Add(tWhatComponent.WhatComponent);
                allComponents.Add(tWhatComponent.WhatComponent);
            }
            List<int> tempDominant = new List<int>();
            foreach (StructComponentLocation tStruct in tEntity.WhereAndWhatsOnMe)
            {
                tempDominant.Add(tStruct.WhatComponentData.WhatComponent);
                RecessiveGenes.Remove(tStruct.WhatComponentData.WhatComponent);
            }
            DominantGenes.AddRange(tempDominant);
        }

        float DominantChance = 100f / (float)DominantGenes.Count;
        float RecesiveChance = 100f / (float)RecessiveGenes.Count;
        float ChanceOfRecesiveTrait = 10f;//100f / (allBodyComponents.Count / (int)(allBodyComponents.Count / allData.Count)); //Last bit is averge component per creature
        List<StructComponentChance> StructChances = new List<StructComponentChance>();
        List<int> checkedComp = new List<int>();
        //Debug.Log(DominantChance + " is chance: count:" + DominantGenes.Count);
        //Debug.Log(RecesiveChance + " is chance: count:" + RecessiveGenes.Count);
        //Debug.Log("Chance of ressive even happening " + ChanceOfRecesiveTrait);
        //Debug.Log(allComponents.Count + " all count:");
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
        checkedComp.Clear();// = new List<int>();
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
        List<int> probabiltyList = new List<int>();

        for (int i = 0; i < allComponents.Count; i++)//averge; i++)
        {
            float whatChances = Random.Range(0f, 100f);
            if (ChanceOfRecesiveTrait < whatChances)
            {
                //Dominate chance
                probabiltyList.Add(Probabilty(StructChances, true));
            }
            else
            {
                //Recessive chance
                probabiltyList.Add(Probabilty(StructChances, false));
            }
        }
        /*
        List<ComponentData> listComponentDataNew = new List<ComponentData>();
        foreach (int temp in probabiltyList)
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
        */
        List<int> listComponentDataNew = new List<int>();
        foreach (int temp in probabiltyList)
        {
            listComponentDataNew.Add(temp);
        }

        /*
        List<StructHaveToPlace> tempPLACE = allData[0].RequiredPlacement; //NOT RANDOM RIGHT NOW           allData[Random.Range(0, allData.Count)].RequiredPlacement;
        for (int i = 0; i < tempPLACE.Count; i++)
        {
            StructHaveToPlace tStruct = tempPLACE[i];
            tStruct.HowManyPlaced = 0;
            tempPLACE[i] = tStruct;
        }
        //testData.makeData(name1, mainBody1, numberOfComponents1, listComponentDataNew, tempPLACE);
        */
        List<int> PlaceList2 = new List<int> { 0, 1, 2, 3, 2, 3 };
        //EntityData testData = (EntityData)ScriptableObject.CreateInstance("EntityData");
        EntityData testData;
        //string result = "";
        //foreach (var item in testData.WhatComps)
        //{
        //    result += item.ToString() + ", ";
        //}
        
        if(runCreation)
        {
            testData = Creation(name1, mainBody1, numberOfComponents1, listComponentDataNew, PlaceList2, false);
            RandomColor(testData);
            StartCoroutine(EditEntityMode(testData));
        }
        else
        {
            testData = Creation(name1, mainBody1, numberOfComponents1, listComponentDataNew, PlaceList2, true);
            RandomColor(testData);
        }
        return testData;
    }
    IEnumerator EditEntityMode(EntityData eData)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        //Rigidbody rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        //rb.kinematic
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
        //Camera.main.transform.GetComponentInParent<PlayerController>().enabled = false;
        //Camera.main.gameObject.GetComponentInParent<MouseLook>().enabled = false;
        int interpolationFramesCount = 100;
        int elapsedFrames = 0;
        bool first = true;
        Vector3 newLocation = Vector3.zero;//transform.position + (Random.onUnitSphere * 5); ;
        Vector3 oldLocation = Camera.main.transform.position;

        // Text WhatSelection = tempUI.transform.GetChild(0).gameObject.GetComponent<Text>();
        // Text TextHowManyLeft = tempUI.transform.GetChild(1).gameObject.GetComponent<Text>();
        int howManyPlacesLeft = eData.NumberOfComponents;
        //Debug.Log(howManyPlacesLeft + " How many places left");
        //Debug.Log(howManyPlacesLeft);
        for (int x = 0; x < eData.WhatComps.Count; x++)
        {
            // Instantiate(tempImagePrefab, tempUI.transform).GetComponent<Image>().sprite = allSprites[eData.WhatComps[x].WhatComponent];
        }
        Vector3 locationOfSpawner = GameObject.FindGameObjectWithTag("GenerateCreature").transform.position;
        // GameObject CurrentEditor = Instantiate(eData.MainBody, transform.position, new Quaternion());
        GameObject CurrentEditor = Instantiate(eData.MainBody, locationOfSpawner, new Quaternion());
        float rayLength = 15.0f;
        RaycastHit hit;
        bool wait = false;
        GameObject currentComponent = null;

        while (true)
        {
            float interpolationRatio = ((float)elapsedFrames / interpolationFramesCount);
            Vector3 interpolatedPosition = Vector3.Lerp(oldLocation, newLocation, interpolationRatio);
            if (interpolatedPosition.Equals(newLocation) || first)
            {
                wait = true;
                first = false;
                whatValueSelection = Random.Range(0, eData.WhatComps.Count - 1);
                // WhatSelection.text = whatValueSelection + "";
                // TextHowManyLeft.text = TextHowManyLeft.text.Substring(0, TextHowManyLeft.text.IndexOf(":") + 1) + " " + howManyPlacesLeft;
                if (currentComponent != null)
                {
                    currentComponent.SetActive(true);
                    yield return new WaitForSeconds(.1f);
                }
                currentComponent = newComponentGen(CurrentEditor, eData, whatValueSelection, false, Vector3.zero);
                
                newLocation = findLocationForCamera(CurrentEditor.GetComponentInChildren<Renderer>().bounds.center, currentComponent.transform.position);

                oldLocation = Camera.main.transform.position;
            }
            else
            {
                Camera.main.transform.position = interpolatedPosition;
                // Camera.main.transform.LookAt(transform.position);
                Camera.main.transform.LookAt(locationOfSpawner);
            }
            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
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
                    //eData.WhereAndWhatsOnMe.Add(new StructComponentLocation(eData.WhatComps[whatValueSelection], hit.point));
                    howManyPlacesLeft -= 1;
                    //Debug.Log(howManyPlacesLeft + " How many places left");
                    if (howManyPlacesLeft < 0)
                    {
                        break;
                    }

                    //howManyPlacesLeft -= 1;
                }
                else
                {
                    //POOF animation
                    //error sound clip
                }
            }
            yield return new WaitForSeconds(.00001f);
        }
        if (currentComponent != null)
        {
            currentComponent.SetActive(true);
            yield return new WaitForSeconds(.1f);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
        //Camera.main.transform.position = GameObject.FindGameObjectWithTag("CameraPosition").transform.position;
        //Camera.main.transform.rotation = GameObject.FindGameObjectWithTag("CameraPosition").transform.rotation;
        //Camera.main.gameObject.GetComponentInParent<PlayerController>().enabled = true;
        //Camera.main.gameObject.GetComponentInParent<MouseLook>().enabled = true;
        onDeckData = eData;
        Destroy(CurrentEditor, 5f);
        TriggerEnityCreation.DoneGene = true;
        StopCoroutine(EditEntityMode(eData));
        yield return null;
    }
    #endregion

    #region HelperFunctions

    public Vector3 testVector;
    public Vector3 testMiddle;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(testVector) * 15;
        Gizmos.DrawRay(testMiddle, direction);
    }

    void RandomColor(EntityData tempData)
    {
        Color BaseColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Color SecondColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        tempData.mat1 = new Material(BaseCOLOR);
        tempData.mat2 = new Material(SecondCOLOR);
        tempData.mat1.color = BaseColor;//BaseColor;
        tempData.mat2.color = SecondColor;//SecondColor;
    }

    int validComponent(EntityData tempData, int testComponent)
    {
        ComponentData compData = tempData.WhatComps[testComponent];
        bool requeredPlacesLeft = false;
        foreach (StructHaveToPlace data in tempData.RequiredPlacement)
        {
            if (data.HowMany > data.HowManyPlaced)
            {
                //Debug.Log("What Component" + testComponent + " How many" + data.HowMany + " How many placed" + data.HowManyPlaced);
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
            for (int i = 0; i < tempData.RequiredPlacement.Count; i++)
            {
                if (compData.WhereCanPlace.Contains(tempData.RequiredPlacement[i].WhatSide) //== tempData.RequiredPlacement[i].WhatSide
                        && tempData.RequiredPlacement[i].HowMany > tempData.RequiredPlacement[i].HowManyPlaced
                        && compData.WhereCanPlace.Contains(tempData.RequiredPlacement[i].WhatSide))
                {
                    return testComponent;
                }
            }
            /*
            for (int k = 0; k < compData.WhereCanPlace.Count * 3; k++)
            {
                int randomTry = compData.WhereCanPlace[Random.Range(0, compData.WhereCanPlace.Count)];
                for (int i = 0; i < tempData.RequiredPlacement.Count; i++)
                {
                    if (randomTry == tempData.RequiredPlacement[i].WhatSide
                        && tempData.RequiredPlacement[i].HowMany > tempData.RequiredPlacement[i].HowManyPlaced
                        && compData.WhereCanPlace.Contains(tempData.RequiredPlacement[i].WhatSide))
                    {
                        return randomTry;
                    }
                }
            }
            */
            return validComponent(tempData, Random.Range(0, tempData.WhatComps.Count));
        }
        else
        {
            return testComponent;
        }
    }

    int GenerateWhere(EntityData eData, ComponentData componentData)
    {
        bool requeredPlacesLeft = false;
        foreach (StructHaveToPlace data in eData.RequiredPlacement)
        {
            if (data.HowMany > data.HowManyPlaced && componentData.WhereCanPlace.Contains(data.WhatSide))
            {
                requeredPlacesLeft = true;
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
                        //Debug.Log("Should happen like now");
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

    private Vector3 findLocationForCamera(Vector3 mainBodyMiddlePosition ,Vector3 componentPosition)
    {
        float radius = 3.5f;
        Vector3 center = mainBodyMiddlePosition;
        Vector3 target = componentPosition - center;
        target.Scale(new Vector3(20, 20, 20));
        //FOR Gizmo testing
        testVector = target;
        testMiddle = center;
        //------------------
        Vector3 direction = transform.TransformDirection(target);
        Vector3 OC;
        OC.x = center.x - center.x;
        OC.y = center.y - center.y;
        OC.z = center.z - center.z;
        float a = Vector3.Dot(direction, direction);
        float b = Vector3.Dot(direction, OC);
        float c = Vector3.Dot(OC, OC) - radius * radius;
        float delta = b * b - a * c;
        if (delta < 0)
        {
            Debug.LogError("This should never happen  delta: " + delta);
            throw new System.Exception("No solution");
        }
        float sqrtDelta = Mathf.Sqrt(delta);
        float tMin = (-b - sqrtDelta) / a;
        float tMax = (-b + sqrtDelta) / a;
        if (tMax < 0)
        {
            Debug.LogError("This should never happen  tMax: " + tMax);
            throw new System.Exception("Behind Ray");
        }
        float t = tMin >= 0 ? tMin : tMax;
        return new Vector3(center.x + t * direction.x, center.y + t * direction.y, center.z + t * direction.z);

    }

    void MoveMeshesAndScale(GameObject mainBody, GameObject tempComponent)
    {
        if (tempComponent.name.Contains("Leg"))
        {
            Renderer collider = tempComponent.GetComponentInChildren<Renderer>();
            Bounds bounds = collider.bounds;
            Vector3 mainBounds = collider.bounds.size;
            Vector3 compBounds = bounds.size;
            Vector3 scale = new Vector3(mainBounds.x / compBounds.x, mainBounds.y / compBounds.y, mainBounds.z / compBounds.z);
            tempComponent.transform.localScale = scale;
        }
        Vector3 closestPoint = mainBody.GetComponentInChildren<MeshCollider>().ClosestPoint(tempComponent.transform.position);
        tempComponent.transform.position = closestPoint;
    }

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

    #endregion
}
