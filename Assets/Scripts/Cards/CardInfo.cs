using CardGame.Model.Cards.Interfaces;
using CardGame.Model.Engine;
using UnityEngine;

namespace Cards
{
    public class CardInfo : MonoBehaviour
    {
        private ICard Card { get; set; }

        public void Initialize()
        {
            Card = new SampleMinion();
        }

        public void Update()
        {
            
        }

        public void OnPlay()
        {
            GameEventManager.CardPlayed(Card as IMinion);
            Debug.Log("Card played Id " + Card.Id);
            Debug.Log("Card attack is: " + Card.BaseCost);
        }
    }
}
