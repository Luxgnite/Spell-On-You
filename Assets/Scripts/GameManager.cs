using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public List<Player> players;
    public int nbPlayers = 4;
    public Player playerPrefab;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireValidateEvent()
    {
        Debug.Log("Firing Validate Event");
        validateEvent();
    }
}
