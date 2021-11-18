using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour 
{
    public GameObject[] uis;
    int id = 0;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
           
        }
	}

    public void Press()
    {
        id++;
        if (id >= uis.Length)
        {
            id = 0;
        }

        for (int m = 0; m < uis.Length; m++)
        {
            uis[m].SetActive(false);
        }

        uis[id].SetActive(true);
    }
}

