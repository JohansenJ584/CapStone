using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnityCreation : MonoBehaviour
{
    bool once = true;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController pCon))
        {
            if(Input.GetKey(KeyCode.F) && once)
            {
                once = false;
                EntityCreation._instance.StartCreationTest();
            }
        }
    }
}
