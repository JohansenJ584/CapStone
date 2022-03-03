using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

public class MyNetworkManager : NetworkManager
{
    /*
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("Connected to server");
    }
    */
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();
        player.SetDisplayName($"Player {numPlayers}");

        player.SetDisplayColor(new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        //Debug.Log($"There are now {numPlayers} players");
    }

}
