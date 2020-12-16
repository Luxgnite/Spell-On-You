using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string cardName;
    public string text;
    public Sprite illustation;

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
    Image UIcardIllu;

    void Awake()
    {
        UIcardTitle = this.transform.Find("Titre").GetComponent<Text>();
        UIcardText = this.transform.Find("Text").GetComponent<Text>();
        UIcardIllu = this.transform.Find("Illustration").GetComponent<Image>();
    }

    void getDataCard()
    {
        this.cardName = data.cardName;
        this.text = data.text;
        this.illustation = data.illustration;

        UIcardTitle.text = this.cardName;
        UIcardText.text = this.text;
        UIcardIllu.sprite = this.illustation;
    }
}
