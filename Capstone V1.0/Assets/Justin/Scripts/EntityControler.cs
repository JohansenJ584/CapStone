using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityControler : MonoBehaviour
{
    public EntityData myData;
    [SerializeField] private GameObject AIComponent;
    public void addAi()
    {
        foreach (var component in AIComponent.GetComponents<Component>())
        {
            var componentType = component.GetType();
            if (componentType != typeof(Transform) &&
                componentType != typeof(MeshFilter) &&
                componentType != typeof(MeshRenderer)
                )
            {
                Debug.Log("Found a component of type " + component.GetType());
                UnityEditorInternal.ComponentUtility.CopyComponent(component);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(gameObject);
                Debug.Log("Copied " + component.GetType() + " from " + AIComponent.name + " to " + gameObject.name);
            }
        }
        gameObject.GetComponent<SimpleCreatureAI>().agent = gameObject.GetComponent<NavMeshAgent>();
        //Instantiate(AIComponent, gameObject.transform);
    }
}
