using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTestSpawn : MonoBehaviour
{
    bool ok = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController pCon))
        {
            if (Input.GetKey(KeyCode.F) && ok)
            {
                ok = false;
                for (int i = 0; i < Random.Range(3f,6f); i++)
                {
                    EntityCreation._instance.OnFinshMonster(null, gameObject.transform.position + Vector3.up * 3f + Vector3.right * 2f);
                }
                Invoke("changeOK", 10f);
            }
        }
    }

    void changeOK()
    {
        ok = true;
    }
}
