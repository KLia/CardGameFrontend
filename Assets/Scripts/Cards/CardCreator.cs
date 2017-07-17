using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Cards
{
    public class CardCreator : MonoBehaviour
    {
        public static CardCreator Instance;

        public RectTransform Hand;
        public GameObject CardPrefab;

        public void Start()
        {
            Instance = this;
        }
        
        public void AddCardToHand()
        {
            if (Hand.childCount >= 7)
            {
                return;
            }

            PlayerUtils.SpawnCardWithClientAuthority();
        }
    }
}
