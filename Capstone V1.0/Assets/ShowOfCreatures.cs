using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOfCreatures : MonoBehaviour
{
    private List<EntityData> listData;

    private List<GameObject> AllSpawned = new List<GameObject>();
    void Start()
    {
        Invoke("LateStart", 2f);
    }

    void LateStart()
    {
        listData = EntityCreation._instance.eLists;
        foreach (Transform child in transform)
        {
            GameObject newObject = EntityCreation._instance.OnFinshDisplay(listData[Random.Range(0, listData.Count)], child.position);
            newObject.transform.Rotate(0f, 180f, 0f);
            AllSpawned.Add(newObject);
            AllSpawned[AllSpawned.Count - 1].transform.parent = child;
        }
        InvokeRepeating("UpdateEveryBit", 1.0f, .1f);
    }

    void UpdateEveryBit()
    {
        int place = Random.Range(0, AllSpawned.Count);
        GameObject toDie = AllSpawned[place];
        Transform oldParent = AllSpawned[place].transform.parent;
        AllSpawned.RemoveAt(place);
        AllSpawned.Add(EntityCreation._instance.OnFinshDisplay(EntityCreation._instance.CombineTwoOrMoreEntitys(listData, false), oldParent.position));
        AllSpawned[AllSpawned.Count - 1].transform.parent = oldParent;
        AllSpawned[AllSpawned.Count - 1].transform.Rotate(0f, 180f, 0f);
        Destroy(toDie);
    }
}
