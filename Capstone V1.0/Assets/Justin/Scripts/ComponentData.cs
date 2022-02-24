using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ComponentData")]
public class ComponentData : MonoBehaviour
{
    public string componentName;
    public int WhatComponent;
    public List<int> WhereCanPlace = new List<int>();
    //public GameObject itself;
    //private void Start()
    //{
    //    itself = gameObject;
    //}
}
