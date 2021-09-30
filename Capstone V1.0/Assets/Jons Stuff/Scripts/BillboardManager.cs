using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardManager : MonoBehaviour
{

    public GameObject[] billboards;
    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }
    void LateUpdate()
    {
        foreach (GameObject go in billboards)
        {
            go.transform.rotation = mainCam.transform.rotation;
           // go.transform.rotation = Quaternion.Euler(0f, go.transform.rotation.eulerAngles.y, 0f);
        }
    }
}
