using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string cardName;
    public string text;
    public Sprite illustation;
    public Categorie categorie;
    public Thematique theme;
    public int nbCoeur = 1;

    public bool isSelectable = false;
    public bool selected = false;
    RectTransform rectTrans;
    Vector2 standardSize;

    CardData data;

    public CardData Data
    {
        set
        {
            if (value != null)
            {
                data = value;
                GetDataCard();
            }
        }
    }

    Image UIIcon;

    void Awake()
    {
        UIIcon = this.transform.Find("Reflection").GetComponent<Image>();
        
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
        //this.gameObject.GetComponent<Image>().color = Color.white;
    }

    public void MakeUnselectable()
    {
        isSelectable = false;
        //this.gameObject.GetComponent<Image>().color = Color.gray;
    }

    public void SetVisibility(bool visibility)
    {
        foreach(Image image in this.GetComponentsInChildren<Image>())
        {
            image.enabled = visibility;
        }
        foreach (Text text in this.GetComponentsInChildren<Text>())
        {
            text.enabled = visibility;
        }
    }

    void GetDataCard()
    {
        this.cardName = data.cardName;
        this.text = data.text;
        this.illustation = data.illustration;
        this.categorie = data.categorie;
        this.theme = data.theme;
        this.nbCoeur = data.nbCoeur;

        UIIcon.sprite = GameManager.Instance.iconsCategorie[(int) categorie];
        UIIcon.color = GameManager.Instance.colorsThemes[(int) theme];

        /*Transform gemme = this.transform.Find("Gemme");
        for(int i = 1; i < nbCoeur; i++)
        {
            GameObject temp = GameObject.Instantiate(gemme.gameObject);
            temp.transform.SetParent(gemme.parent);
        }*/

        RemoveListeners();
        AddListeners();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    public void AddListeners()
    {
        GameManager.allCardSelectableEvent += OnSelectableBroadcast;
        GameManager.allCardUnselectableEvent += OnUnselectableBroadcast;

        switch (this.categorie)
        {
            case Categorie.Photo:
                GameManager.cardPhotoSelectableEvent += OnSelectableBroadcast;
                GameManager.cardPhotoUnselectableEvent += OnUnselectableBroadcast;
                break;
            case Categorie.Description:
                GameManager.cardDescrSelectableEvent += OnSelectableBroadcast;
                GameManager.cardDescrUnselectableEvent += OnUnselectableBroadcast;
                break;
            case Categorie.Hashtag:
                GameManager.cardHashtagSelectableEvent += OnSelectableBroadcast;
                GameManager.cardHashtagUnselectableEvent += OnUnselectableBroadcast;
                break;
            case Categorie.Lieu:
                GameManager.cardLieuSelectableEvent += OnSelectableBroadcast;
                GameManager.cardLieuUnselectableEvent += OnUnselectableBroadcast;
                break;
            default:
                break;
        }
    }

    public void RemoveListeners()
    {
        GameManager.allCardSelectableEvent -= OnSelectableBroadcast;
        GameManager.allCardUnselectableEvent -= OnUnselectableBroadcast;
        GameManager.cardPhotoSelectableEvent -= OnSelectableBroadcast;
        GameManager.cardPhotoUnselectableEvent -= OnUnselectableBroadcast;
        GameManager.cardDescrSelectableEvent -= OnSelectableBroadcast;
        GameManager.cardDescrUnselectableEvent -= OnUnselectableBroadcast;
        GameManager.cardHashtagSelectableEvent -= OnSelectableBroadcast;
        GameManager.cardHashtagUnselectableEvent -= OnUnselectableBroadcast;
        GameManager.cardLieuSelectableEvent -= OnSelectableBroadcast;
        GameManager.cardLieuUnselectableEvent -= OnUnselectableBroadcast;
    }

    public void OnClicked()
    {
        if (isSelectable)
        {
            selected = !selected ? true : false;
            //rectTrans.sizeDelta = selected ? rectTrans.sizeDelta * 1.2f : new Vector2(standardSize.x, standardSize.y);
            CardManager.FireCardSelectedEvent(this);
        }
    }

    public void OnSelectableBroadcast()
    {
        Debug.Log("OnSelectableBroadcast");
        MakeSelectable();
    }

    public void OnUnselectableBroadcast()
    {
        Debug.Log("OnUnselectableBroadcast");
        MakeUnselectable();
    }
}
