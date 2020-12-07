using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> cardsPile;

    public CardData[] datas;
    public Card cardPrefab;


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
}
