using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostViewer : MonoBehaviour
{
    public Post postLinked;

    public Image photo;
    public Text description;
    public Text hashtag;
    public Text lieu;
    public Text score;

    private void Awake()
    {
        Post.cardChangeEvent += OnChangeCard;
        Post.archivedEvent += OnArchivedPost;
        this.gameObject.SetActive(false);
    }

    public Post PostLinked
    {
        set
        {
            postLinked = value;
            Init();
        }
    }

    void Init()
    {
        photo.sprite = postLinked.Photo != null ? postLinked.Photo.illustation : null;
        description.text = postLinked.Description != null ? postLinked.Description.text : null;
        hashtag.text = postLinked.Hashtag != null ? postLinked.Hashtag.text : null;
        lieu.text = postLinked.Lieu != null ? postLinked.Lieu.text : null;
        score.text = postLinked.ScoreCalculation().ToString();
    }

    void ChangeLieu(Card card)
    {
        lieu.text = card.text;
    }

    void ChangeHashtag(Card card)
    {
        hashtag.text = "#" + card.text;
    }

    void ChangeDescription(Card card)
    {
        description.text = card.text;
    }

    void ChangePhoto(Card card)
    {
        photo.sprite = card.illustation;
    }

    void OnChangeCard(Post postSender, Card cardChanged)
    {
        switch (cardChanged.categorie)
        {
            case Categorie.Lieu:
                ChangeLieu(cardChanged);
                break;
            case Categorie.Description:
                ChangeDescription(cardChanged);
                break;
            case Categorie.Photo:
                ChangePhoto(cardChanged);
                break;
            case Categorie.Hashtag:
                ChangeHashtag(cardChanged);
                break;
            default:
                break;
        }
        score.text = postSender.ScoreCalculation().ToString();
    }

    void OnArchivedPost(Post postSender, Card cardChanged)
    {
        Destroy(this.gameObject);
    }
}
