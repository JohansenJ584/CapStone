using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinChildObject : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).Rotate(50 * Time.deltaTime, 50 * Time.deltaTime, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
