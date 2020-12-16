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
        GameManager.validateEvent += OnValidation;
        //InputController.fireEvent += OnFire;
    }

    protected override void RemoveListeners()
    {
        Debug.Log("Removing Listeners");
        GameManager.validateEvent -= OnValidation;
        //InputController.fireEvent -= OnFire;
    }

    protected virtual void OnValidation()
    {
        Debug.Log("OnValidate in " + this.GetType().Name);
    }

    /*
    protected virtual void OnEvent(object sender, InfoEventArgs<Point> e)
    {

    }
    */

}