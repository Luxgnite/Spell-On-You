using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    /// <summary>
    /// Get the actual instance of the Game Manager.
    /// </summary>
    public static GameManager Instance { get { return _instance;  } }

    public List<Player> players;
    public int nbPlayers;
    public Player playerPrefab;

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
            players[players.Count -1 ].name = "J" + players.Count;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
