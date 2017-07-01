using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Cards
{
    public class CardCreator : MonoBehaviour
    {
        public RectTransform Hand;
        public GameObject CardPrefab;

        public void Start()
        {
        }

        //[Command]
        public void CmdAddCardToHand()
        {
            if (Hand.childCount >= 7)
            {
                return;
            }

            var cardInstance = Instantiate(CardPrefab);
            cardInstance.GetComponent<Image>().color = Random.ColorHSV();
            cardInstance.transform.SetParent(Hand);
            cardInstance.tag = "Card";
            //NetworkServer.SpawnWithClientAuthority(cardInstance, connectionToServer); //Spawn the Card on the server

            var ci = cardInstance.GetComponent<CardInfo>();
            ci.Initialize();
        }
    }
}
