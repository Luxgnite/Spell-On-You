using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : StateMachine
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        ChangeState<InitTurnState>();
    }
}