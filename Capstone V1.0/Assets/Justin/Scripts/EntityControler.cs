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
        float lowestPointy = Mathf.Infinity;
        float HighestPointy = Mathf.NegativeInfinity;
        foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
        {
            if(lowestPointy > rend.bounds.min.y)
            {
                lowestPointy = rend.bounds.min.y;
            }
            if (HighestPointy < rend.bounds.max.y)
            {
                HighestPointy = rend.bounds.max.y;
            }
        }
        //Debug.Log(gameObject.GetComponent<NavMeshAgent>().baseOffset);
        gameObject.GetComponent<NavMeshAgent>().baseOffset = Mathf.Abs((gameObject.transform.position.y - lowestPointy)) - 0.15f;// / 1.5f;//Mathf.Abs(gameObject.transform.position.y - lowestPoint.y/1.5f);
        //Debug.Log(gameObject.GetComponent<NavMeshAgent>().baseOffset + " After");
        gameObject.GetComponent<NavMeshAgent>().height = Mathf.Abs(HighestPointy - lowestPointy);
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
        // UnityEditorInternal.ComponentUtility.comp
        BoxCollider sc = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        float lowestPointy = Mathf.Infinity;
        float HighestPointy = Mathf.NegativeInfinity;
        float lowestPointx = Mathf.Infinity;
        float HighestPointx = Mathf.NegativeInfinity;
        float lowestPointz = Mathf.Infinity;
        float HighestPointz = Mathf.NegativeInfinity;
        foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
        {
            //y
            if (lowestPointy > rend.bounds.min.y)
            {
                lowestPointy = rend.bounds.min.y;
            }
            if (HighestPointy < rend.bounds.max.y)
            {
                HighestPointy = rend.bounds.max.y;
            }
            //x
            if (lowestPointx > rend.bounds.min.x)
            {
                lowestPointx = rend.bounds.min.x;
            }
            if (HighestPointx < rend.bounds.max.x)
            {
                HighestPointx = rend.bounds.max.x;
            }
            //z
            if (lowestPointz > rend.bounds.min.z)
            {
                lowestPointz = rend.bounds.min.z;
            }
            if (HighestPointz < rend.bounds.max.z)
            {
                HighestPointz = rend.bounds.max.z;
            }
        }

        float tx = Mathf.Abs(HighestPointx - lowestPointx);
        float ty = Mathf.Abs(HighestPointy - lowestPointy);
        float tz = Mathf.Abs(HighestPointz - lowestPointz);
        sc.size = new Vector3(tx, ty, tz);
        sc.center = new Vector3(sc.center.x, .75f, sc.center.z);



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
