using UnityEngine;
using UnityEngine.Networking;

public class PlayerUtils : NetworkBehaviour
{
    public static PlayerScript PlayerObject;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public static void CreatePlayerObject(PlayerScript ps)
    {
        PlayerObject = ps;
    }

    public static void SpawnWithClientAuthority(GameObject go)
    {
        PlayerObject.CmdSpawnWithClientAuthority(go);
    }
}