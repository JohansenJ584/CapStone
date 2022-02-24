using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;
using TMPro;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField]
    private TMP_Text displayNameText = null;
    [SerializeField]
    private Renderer displayColorRenderer = null;

    [SyncVar(hook = nameof(HandleDisplayNameUpdated))]
    [SerializeField]
    private string displayName = "Missing Name";

    [SyncVar(hook = nameof(HandleDisplayColorUpdated))]
    [SerializeField]
    private Color displayColor = Color.black;

    #region Server

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [Server]
    public void SetDisplayColor(Color newDisplayColor)
    {
        displayColor = newDisplayColor;
    }
    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        if(newDisplayName.Length < 2 || newDisplayName.Length > 20)
        {
            return;
        }

        RpcLogNewName(newDisplayName);

        SetDisplayName(newDisplayName);
    }

    #endregion

    #region Client

    private void HandleDisplayNameUpdated(string oldName, string newName)
    {
        displayNameText.text = displayName;
    }

    private void HandleDisplayColorUpdated(Color oldColor, Color newColor)
    {
        displayColorRenderer.material.SetColor("_BaseColor", newColor);
    }
    [ContextMenu("Set My name")]
    private void SetMyName()
    {
        CmdSetDisplayName("M");
    }
    [ClientRpc]
    private void RpcLogNewName(string newDisplayName)
    {
        Debug.Log(newDisplayName);
    }

    #endregion
}
