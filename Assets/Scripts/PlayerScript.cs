using Cards;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerScript : NetworkBehaviour
{
    [SyncVar] private int _numberOfConnectedPlayers;
    private int _playerId;

    public void Update()
    {
        Debug.Log("Local Player: " + isLocalPlayer);
        Debug.Log("Server: " + isServer);
        Debug.Log("Client: " + isClient);
        Debug.Log("Has Authority: " + hasAuthority);
    }

    public override void OnStartLocalPlayer()
    {
        PlayerUtils.CreatePlayerObject(this);
        _numberOfConnectedPlayers++;
        _playerId = _numberOfConnectedPlayers;
    }

    [Command]
    public void CmdSpawnCardWithClientAuthority()
    {
        var cardInfo = Instantiate(CardCreator.Instance.CardPrefab);
        NetworkServer.SpawnWithClientAuthority(cardInfo, connectionToClient);
        RpcSpawnOpponentCardOnClient(cardInfo);
    }

    [ClientRpc]
    public void RpcSpawnOpponentCardOnClient(GameObject cardInfo)
    {
        cardInfo.GetComponent<Image>().color = Random.ColorHSV();
        cardInfo.tag = "Card";
        var ci = cardInfo.GetComponent<CardInfo>();
        ci.Initialize();

        if (!isServer && !isLocalPlayer)
        {
            var board = GameObject.Find("OpponentBoard");
            cardInfo.transform.SetParent(board.transform);
            Debug.Log("Added Card to Hand");
        }
        else if (isLocalPlayer)
        {
            var board = GameObject.Find("Hand");
            cardInfo.transform.SetParent(board.transform);
        }
    }
}