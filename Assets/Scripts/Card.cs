using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string cardName;
    public string text;

    CardData data;

    public CardData Data
    {
        set
        {
            if(value != null)
            {
                data = value;
                getDataCard();
            }
        }
    }

    Text UIcardTitle;
    Text UIcardText;

    void Awake()
    {
        UIcardTitle = this.transform.Find("Titre").GetComponent<Text>();
        UIcardText = this.transform.Find("Text").GetComponent<Text>();
    }

    void getDataCard()
    {
        this.cardName = data.cardName;
        this.text = data.text;

        UIcardTitle.text = this.cardName;
        UIcardText.text = this.text;
    }
}
