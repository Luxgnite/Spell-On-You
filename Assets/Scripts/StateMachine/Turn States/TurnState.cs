using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnState : State
{
    protected TurnController owner;

    public GameManager gameManager { get { return owner.gameManager;  } }

    protected virtual void Awake()
    {
        owner = GetComponent<TurnController>();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Charging " + this.GetType().Name);
    }

    protected override void AddListeners()
    {
        Debug.Log("Adding Listeners");
        //InputController.fireEvent += OnFire;
    }

    protected override void RemoveListeners()
    {
        Debug.Log("Removing Listeners");
        //InputController.fireEvent -= OnFire;
    }

    /*
    protected virtual void OnEvent(object sender, InfoEventArgs<Point> e)
    {

    }
    */

}