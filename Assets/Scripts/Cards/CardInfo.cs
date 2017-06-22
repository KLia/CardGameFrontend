using CardGame.Model.Cards;
using CardGame.Model.Cards.Interfaces;
using CardGame.Model.Engine;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class CardInfo : MonoBehaviour
    {
        private ICard Card { get; set; }

        public void Initialize()
        {
            Card = new SampleMinion();
        }

        public void OnPlay()
        {
            GameEventManager.CardPlayed(Card as IMinion);
            Debug.Log("Card played Id " + Card.Id);
            Debug.Log("Card attack is: " + Card.BaseCost);
        }
    }
}
