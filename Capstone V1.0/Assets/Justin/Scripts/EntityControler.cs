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
        gameObject.GetComponent<NavMeshAgent>().baseOffset = Mathf.Abs((HighestPoint.y - lowestPoint.y)/8f);// / 1.5f;//Mathf.Abs(gameObject.transform.position.y - lowestPoint.y/1.5f);
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
    
    public void finshItUp()
    {
        //Remove Colliders
        foreach (Collider coll in gameObject.GetComponentsInChildren<Collider>())
        {
            Destroy(coll);
        }

        foreach (Transform tran in gameObject.GetComponentsInChildren<Transform>())
        {
            if (tran.name.Contains("Legs") && tran.name.Contains("Component"))
            {
                SkinnedMeshRenderer meshRendComp = tran.GetComponentInChildren<SkinnedMeshRenderer>();
                SkinnedMeshRenderer meshRendBody =  gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

                //Bounds bounds = meshRend.bounds;
                //foreach (var c in collider) 
                //bounds = bounds.Encapsulate(collider.bounds);
                //Debug.Log("LEGSS FOUNFD");
                Vector3 mainBounds = meshRendBody.bounds.size;
                Vector3 compBounds = meshRendComp.bounds.size;
                // mainBounds.y / compBounds.y
                Vector3 scale = new Vector3(mainBounds.x / compBounds.x, tran.localScale.y, mainBounds.z / compBounds.z);
                tran.localScale = scale;

            }
        }
    }
}
