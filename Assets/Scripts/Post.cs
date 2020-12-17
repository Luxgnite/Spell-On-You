using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Post
{
    public delegate void PostEvent(Post postSender, Card cardChanged);
    public static event PostEvent cardChangeEvent;
    public static event PostEvent archivedEvent;

    public Player playerOwner;

    private Card photo;
    public Card Photo { get { return photo; } }
    private Card lieu;
    public Card Lieu { get { return Lieu; } }
    private Card hashtag;
    public Card Hashtag { get { return Hashtag; } }
    private Card description;
    public Card Description { get { return Description; } }

    public Post(Player player)
    { 
        playerOwner = player;
    }

    public void AddCard(Card cardToAdd)
    {
        switch(cardToAdd.categorie)
        {
            case Categorie.Lieu:
                if (lieu != null)
                    playerOwner.AddCardHand(lieu);
                lieu = cardToAdd;
                playerOwner.RemoveCardHand(cardToAdd);
                cardChangeEvent(this, lieu);
                break;
            case Categorie.Description:
                if (description != null)
                    playerOwner.AddCardHand(description);
                description = cardToAdd;
                playerOwner.RemoveCardHand(cardToAdd);
                cardChangeEvent(this, description);
                break;
            case Categorie.Photo:
                if (photo != null)
                    playerOwner.AddCardHand(photo);
                photo = cardToAdd;
                playerOwner.RemoveCardHand(cardToAdd);
                cardChangeEvent(this, photo);
                break;
            case Categorie.Hashtag:
                if (hashtag != null)
                    playerOwner.AddCardHand(hashtag);
                hashtag = cardToAdd;
                playerOwner.RemoveCardHand(cardToAdd);
                cardChangeEvent(this, hashtag);
                break;
            default:
                break;
        }
    }

    public int ScoreCalculation()
    {
        int result = 0;
        result += photo.nbCoeur;
        if (lieu != null) { result += lieu.categorie == photo.categorie ? lieu.nbCoeur * 2 : lieu.nbCoeur; }
        if (hashtag != null) { result += hashtag.categorie == photo.categorie ? hashtag.nbCoeur * 2 : hashtag.nbCoeur; }
        if (description != null) { result += description.categorie == photo.categorie ? description.nbCoeur * 2 : description.nbCoeur; }
        return result *= playerOwner.FollowerCoefficient > 0 ? playerOwner.FollowerCoefficient : 1 ;
    }
}
