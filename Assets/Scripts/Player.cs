using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public  List<Card> cardsHand;
    public List<Card> CardsHand { get { return cardsHand;  } }
    public bool isUser = false;
    public int followers = 0;
    public int gemmes = 0;

    public int Followers
    {
        get
        {
            return followers;
        }
        set
        {
            followers = value;
            GameManager.UserFollowersChanged();
        }
    }

    public int FollowerCoefficient
    {
        get
        {
            if (followers >= 0)
                return followers / 10;
            else
                return 0;
        }
    }

    public void ConvertGemmesIntoFollowers()
    {
        Followers = Followers + (gemmes / 2) * 100; 
    }

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
            card.SetVisibility(true);
        }
    }

    public void AddCardHand(List<Card> cards)
    {
        foreach(Card card in cards)
        {
            AddCardHand(card);
        }
    }

    public void RemoveCardHand(Card card)
    {
        cardsHand.Remove(card);
        if (isUser)
        {
            card.transform.SetParent(GameObject.Find("InvisibleCards").transform);
            card.SetVisibility(false);
        }
    }
}
