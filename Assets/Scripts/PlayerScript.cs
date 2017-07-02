using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour
{
    public void Update()
    {
        Debug.Log("Local Player: " +isLocalPlayer);
        Debug.Log("Server: " + isServer);
        Debug.Log("Client: " + isClient);
        Debug.Log("Has Authority: " +hasAuthority);
    }

    public override void OnStartLocalPlayer()
    {
        PlayerUtils.CreatePlayerObject(this);
    }

    [Command]
    public void CmdSpawnWithClientAuthority(GameObject go)
    {
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }
}
