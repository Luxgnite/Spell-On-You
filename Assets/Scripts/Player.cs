using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public  List<Card> cardsHand;
    public List<Card> CardsHand { get { return cardsHand;  } }
    public bool isUser = false;

    private GameObject panelHand;

    private void Awake()
    {
        cardsHand = new List<Card>();
        panelHand = GameObject.Find("Hand");
    }

    public void AddCardHand(Card card)
    {
        cardsHand.Add(card);
        if(isUser)
        {
            card.transform.SetParent(panelHand.transform);
            card.gameObject.SetActive(true);
        }
    }

    public void AddCardHand(List<Card> cards)
    {
        foreach(Card card in cards)
        {
            AddCardHand(card);
        }
    }


}
