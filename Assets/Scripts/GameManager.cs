using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CardManager))]
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    /// <summary>
    /// Get the actual instance of the Game Manager.
    /// </summary>
    public static GameManager Instance { get { return _instance;  } }
    private CardManager cardManager;
    public CardManager CardManager { get { return cardManager;  } }

    public delegate void GameEvent();
    public static event GameEvent validateEvent;
    public static event GameEvent allCardSelectableEvent;
    public static event GameEvent allCardUnselectableEvent;
    public static event GameEvent cardPhotoUnselectableEvent;
    public static event GameEvent cardLieuUnselectableEvent;
    public static event GameEvent cardDescrUnselectableEvent;
    public static event GameEvent cardHashtagUnselectableEvent;
    public static event GameEvent cardPhotoSelectableEvent;
    public static event GameEvent cardLieuSelectableEvent;
    public static event GameEvent cardDescrSelectableEvent;
    public static event GameEvent cardHashtagSelectableEvent;
    public static event GameEvent userFollowersChangedEvent;
    public static event GameEvent playerWin;

    public List<Sprite> iconsCategorie = new List<Sprite>();
    public List<Color> colorsThemes = new List<Color>();

    public List<Player> players;
    public int nbPlayers = 4;
    public Player playerPrefab;
    public PostViewer postView;

    public Post actualPost;
    public List<Post> posts;

    private Player user;
    public Player User { get { return user; } }

    void Awake()
    {
        //Singleton Pattern
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        Init();
    }

    void Init()
    {
        for(int i = 0; i < nbPlayers; i++)
        {
            players.Add(GameObject.Instantiate(playerPrefab));
            players[players.Count -1].name = "J" + players.Count;
            players[players.Count -1].playerName = "J" + players.Count;
        }
        players[0].isUser = true;
        user = players[0];
        cardManager = this.gameObject.GetComponent<CardManager>();
        userFollowersChangedEvent += OnFollowersChanged;
        playerWin += OnPlayerWin;
        cardManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPost(Card firstCard)
    {
        actualPost = new Post(user);
        postView.gameObject.SetActive(true);
        postView.postLinked = actualPost;
        actualPost.AddCard(firstCard);
    }

    public void ArchivePost(Post post)
    {
        if (post == actualPost)
            actualPost = null;
        posts.Add(post);
    }

    public static void FireValidateEvent()
    {
        Debug.Log("Firing Validate Event");
        validateEvent();
    }

    public void ButtonFireValidateEvent()
    {
        FireValidateEvent();
    }
    
    public static void CardBroadcastSelectable()
    {
        Debug.Log("Broadcasting selectable state to all");
        allCardSelectableEvent();
    }

    public static void CardBroadcastSelectable(Categorie filtreCategorie)
    {
        Debug.Log("Broadcasting selectable state to all " + System.Enum.GetName(typeof(Categorie), filtreCategorie));
        switch (filtreCategorie)
        {
            case Categorie.Photo:
                if (cardPhotoSelectableEvent != null)
                    cardPhotoSelectableEvent();
                break;
            case Categorie.Description:
                if (cardDescrSelectableEvent != null)
                    cardDescrSelectableEvent();
                break;
            case Categorie.Hashtag:
                if (cardHashtagSelectableEvent != null)
                    cardHashtagSelectableEvent();
                break;
            case Categorie.Lieu:
                if (cardLieuSelectableEvent != null)
                    cardLieuSelectableEvent();
                break;
            default:
                break;
        }
    }

    public static void CardBroadcastUnselectable()
    {
        Debug.Log("Broadcasting unselectable state to all");
        allCardUnselectableEvent();
    }

    public static void CardBroadcastUnselectable(Categorie filtreCategorie)
    {

        Debug.Log("Broadcasting unselectable state to all " + System.Enum.GetName(typeof(Categorie), filtreCategorie));
        switch (filtreCategorie)
        {
            case Categorie.Photo:
                if(cardPhotoUnselectableEvent != null)
                    cardPhotoUnselectableEvent();
                break;
            case Categorie.Description:
                if (cardDescrUnselectableEvent != null)
                    cardDescrUnselectableEvent();
                break;
            case Categorie.Hashtag:
                if (cardHashtagUnselectableEvent != null)
                    cardHashtagUnselectableEvent();
                break;
            case Categorie.Lieu:
                if (cardLieuUnselectableEvent != null)
                    cardLieuUnselectableEvent();
                break;
            default:
                break;
        }
    }

    public static void UserFollowersChanged()
    {
        userFollowersChangedEvent();
    }

    private void OnFollowersChanged()
    {
        GameObject.Find("NbAbonné").GetComponent<Text>().text = User.Followers.ToString();
        GameObject.Find("NbGemme").GetComponent<Text>().text = "x" + User.FollowerCoefficient.ToString();
    }

    private void OnPlayerWin()
    {
    }

    public static void PlayerWin()
    {
        playerWin();
    }
}
