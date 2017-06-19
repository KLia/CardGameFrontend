using UnityEngine;

public class CardInfo : MonoBehaviour
{
    private static int _id;
    public CardType Type { get; set; }
    public int Id { get; private set; }

    public void Initialize(CardType type)
    {
        Type = type;
        Id = _id++;
    }

    public void OnPlay()
    {
        Debug.Log("Card played Id " + Id);
    }
}
