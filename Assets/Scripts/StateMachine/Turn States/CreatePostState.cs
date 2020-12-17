using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePostState : TurnState
{
    public override void Enter()
    {
        base.Enter();
        GameManager.CardBroadcastSelectable();
    }

    protected override void OnSelectedCard(Card cardSender)
    {
        base.OnSelectedCard(cardSender);
        gameManager.actualPost.AddCard(cardSender);
    }
    protected override void OnValidation()
    {
        Debug.Log("OnValidate in CreatePostState...");
        GameManager.CardBroadcastUnselectable();
        gameManager.User.gemmes = gameManager.actualPost.ScoreCalculation();
        StartCoroutine(ValidatePost());
    }

    IEnumerator ValidatePost()
    {
        yield return null;
        owner.ChangeState<EndPhaseOneState>();
    }
}
