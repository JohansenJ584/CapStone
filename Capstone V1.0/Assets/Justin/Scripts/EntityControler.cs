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
                //Debug.Log("Found a component of type " + component.GetType());
                UnityEditorInternal.ComponentUtility.CopyComponent(component);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(gameObject);
                //Debug.Log("Copied " + component.GetType() + " from " + AIComponent.name + " to " + gameObject.name);
            }
        }
        gameObject.GetComponent<CreatureAI>().agent = gameObject.GetComponent<NavMeshAgent>();
        Vector3 lowestPoint = gameObject.transform.position;
        Vector3 HighestPoint = gameObject.transform.position;
        foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
        {
            if(lowestPoint.y > rend.bounds.min.y)
            {
                lowestPoint = rend.bounds.min;
            }
            if (HighestPoint.y < rend.bounds.max.y)
            {
                HighestPoint = rend.bounds.max;
            }
        }
        gameObject.GetComponent<NavMeshAgent>().baseOffset = Mathf.Abs(gameObject.transform.position.y - lowestPoint.y/1.5f);
        gameObject.GetComponent<NavMeshAgent>().height = Mathf.Abs(HighestPoint.y - lowestPoint.y);
        //Instantiate(AIComponent, gameObject.transform);
    }
    public void whatNewColor()
    {
        foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
        {
            if (rend.materials.Length > 1)
            {
                rend.materials[0].color = myData.mat1.color; 
                rend.materials[1].color = myData.mat2.color; 
            }
            else
            {
                rend.materials[0].color = myData.mat1.color;
            }
            rend.enabled = false;
            rend.enabled = true;
        }
    }
}
