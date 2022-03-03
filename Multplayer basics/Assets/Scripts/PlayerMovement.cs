using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private NavMeshAgent agent = null;

    private Camera maineCamera;

    #region Server

    [Command]
    private void CmdMove(Vector3 position)
    {
        if(!NavMesh.SamplePosition(position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
        {
            return;
        }
        agent.SetDestination(hit.position);
    }
    #endregion

    #region Client

    public override void OnStartAuthority()
    {
        maineCamera = Camera.main;
        base.OnStartAuthority();
    }
    [ClientCallback]
    private void Update()
    {
        if(!hasAuthority)
        {
            return;
        }
        if(!Input.GetMouseButtonDown(0))
        {
            return;
        }
        Ray ray = maineCamera.ScreenPointToRay(Input.mousePosition);

        if(!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            return;
        }

        CmdMove(hit.point);
    }

    #endregion

}
