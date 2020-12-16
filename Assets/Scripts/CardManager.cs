using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> cardsPile;

    public CardData[] datas;
    public Card cardPrefab;

    public int handCardMax = 7;

    public void Start()
    {
        cardsPile = new List<Card>();

        for (int i = 0; i < 10; i++)
        {
            Card temp = Instantiate(cardPrefab);
            temp.transform.SetParent(GameObject.Find("Canvas").transform);
            temp.Data = datas[0];
            Debug.Log(temp);
            cardsPile.Add(temp);
        }

        Debug.Log(cardsPile[0].cardName);
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
    }

    public void RefillHands()
    {
        foreach(Player player in GameManager.Instance.players)
        {
            DrawCard(player, player.cardsHand.Count - handCardMax);
        }
    }
}
