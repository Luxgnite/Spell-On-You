using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string cardName;
    public string text;
    public Sprite illustation;
    public bool isSelectable = false;
    public bool selected = false;
    RectTransform rectTrans;
    Vector2 standardSize;

    CardData data;

    public CardData Data
    {
        set
        {
            if(value != null)
            {
                data = value;
                GetDataCard();
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

        rectTrans = this.GetComponent<RectTransform>();
        standardSize = new Vector2(rectTrans.sizeDelta.x, rectTrans.sizeDelta.y);
    }

    public void ToggleSelectable()
    {
        if (isSelectable)
            MakeUnselectable();
        else
            MakeSelectable();
    }

    public void MakeSelectable()
    {
        isSelectable = true;
    }

    public void MakeUnselectable()
    {
        isSelectable = false;
    }

    void GetDataCard()
    {
        this.cardName = data.cardName;
        this.text = data.text;
        this.illustation = data.illustration;

        UIcardTitle.text = this.cardName;
        UIcardText.text = this.text;
        UIcardIllu.sprite = this.illustation;
    }

    public void OnClicked()
    {
        selected =  !selected ?  true : false;
        
        rectTrans.sizeDelta = selected ? rectTrans.sizeDelta * 1.2f : new Vector2(standardSize.x, standardSize.y);
    }
}
