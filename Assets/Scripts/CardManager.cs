using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> cardsPile;
    public List<Card> refCards;

    public CardData[] datas;
    public Card cardPrefab;

    public int handCardMax = 7;

    public delegate void CardEvent(Card cardSender);
    public static event CardEvent cardSelectedEvent;

    public void Init()
    {
        cardsPile = new List<Card>();

        for (int i = 0; i < datas.Length; i++)
        {
            Card temp = Instantiate(cardPrefab, GameObject.Find("InvisibleCards").transform);
            temp.Data = datas[i];
            Debug.Log(temp);
            cardsPile.Add(temp);
            refCards.Add(temp);
            temp.SetVisibility(false);
            if (datas[i].categorie != Categorie.Photo)
            {
                temp = Instantiate(cardPrefab, GameObject.Find("InvisibleCards").transform);
                temp.Data = datas[i];
                Debug.Log(temp);
                cardsPile.Add(temp);
                refCards.Add(temp);
                temp.SetVisibility(false);
            }
        }

        Mix();
    }

    public void Mix()
    {
        // Insert cards at random order into the shuffled list 
        System.Random rand = new System.Random();
        List<Card> temp = new List<Card>();

        // As long as there are any cards left to insert randomly 
        while (cardsPile.Count != 0)
        {
            // Get the index of the random card to insert 
            var i = rand.Next(cardsPile.Count);

            // Insert it 
            temp.Add(cardsPile[i]);

            // Remove from non-shuffled list 
            cardsPile.RemoveAt(i);
        }

        // Set the list of cards to the shuffled list 
        cardsPile = temp;
    }

    public void DrawCard(Player playerDestination, int nbCard = 1)
    {
        // fonction qui sert a piocher une carte
        Debug.Log("Drawing " + nbCard + " for " + playerDestination.playerName + "...");
        for (int i = 0; i < nbCard; i++)
        {
            playerDestination.AddCardHand(cardsPile[0]);
            cardsPile.RemoveAt(0);
        }
    }

    public void RefillHands()
    {
        Debug.Log("Refilling players hands...");
        foreach(Player player in GameManager.Instance.players)
        {
            DrawCard(player, handCardMax - player.CardsHand.Count);
        }
    }

    public static void FireCardSelectedEvent(Card cardSender)
    {
        Debug.Log("Firing Validate Event");
        cardSelectedEvent(cardSender);
    }
}
