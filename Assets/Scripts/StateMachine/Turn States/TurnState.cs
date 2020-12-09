using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnState : State
{
    //protected TurnController owner;

    protected virtual void Awake()
    {
        //owner = GetComponent<TurnController>();
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
    protected virtual void OnEvent()
    {

    }
    */

}