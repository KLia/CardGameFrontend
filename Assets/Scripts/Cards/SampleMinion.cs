using CardGame.Model.Cards;
using CardGame.Model.Cards.Interfaces;

namespace Cards
{
    /// <summary>
    /// Implements SampleMinion
    /// 
    /// TODO : Implement
    /// </summary>
    public class SampleMinion : Minion
    {
        private const int MANA_COST = 5;
        private const int ATTACK = 4;
        private const int HEALTH = 5;

        public SampleMinion()
        {
            BaseAttack = ATTACK;
            BaseHealth = HEALTH;
            BaseCost = MANA_COST;
        }

        public override void OnCardPlayed(ICard card)
        {
            BaseCost += 1;
        }
    }
}