﻿using UnityEngine;
using UnityEngine.UI;

public class CardCreator : MonoBehaviour
{

    public Transform hand;
    public GameObject cardPrefab;

    public void AddCardToHand()
    {
        if (hand.childCount >= 7)
        {
            return;
        }

        cardPrefab = Instantiate(Resources.Load("Card")) as GameObject;
        cardPrefab.GetComponent<Image>().color = Random.ColorHSV();
        cardPrefab.transform.SetParent(hand);
        
        CardInfo ci = cardPrefab.GetComponent<CardInfo>();
        ci.Initialize(CardType.Minion);
    }
}
