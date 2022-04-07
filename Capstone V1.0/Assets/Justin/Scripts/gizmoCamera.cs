using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmoCamera : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 15;
        Gizmos.DrawRay(transform.position, direction);
    }
}
