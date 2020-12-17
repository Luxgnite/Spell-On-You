﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePictureCardState : TurnState
{
    public override void Enter()
    {
        base.Enter();
        GameManager.CardBroadcastUnselectable();
        GameManager.CardBroadcastSelectable(Categorie.Photo);
    }

    protected override void OnSelectedCard(Card cardSender)
    {
        if(cardSender.categorie == Categorie.Photo)
        {
            //StartCoroutine(StartingPost());
        }
        else
        {

        }
    }
    IEnumerator StartingPost()
    {
        GameManager.CardBroadcastSelectable();
        GameManager.CardBroadcastUnselectable(Categorie.Photo);
        yield return null;
        owner.ChangeState<CreatePostState>();
    }

    protected override void OnValidation()
    {
        Debug.Log("OnValidate in CreatePostState...");
        StartCoroutine(ValidatePost());
    }

    IEnumerator ValidatePost()
    {
        yield return null;
        owner.ChangeState<EndPhaseOneState>();
    }
}
