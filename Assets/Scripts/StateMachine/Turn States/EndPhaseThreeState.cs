using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhaseThreeState : TurnState
{
    public override void Enter()
    {
        base.Enter();
        gameManager.postView.gameObject.SetActive(false);
        gameManager.CardManager.RefillHands();
        bool winner = false;
        foreach (Player player in gameManager.players)
        {
            if (player.followers >= 1000000)
            {
                GameManager.PlayerWin();
                winner = true;
            }
        }

        if (!winner)
            StartCoroutine(ChangeState());
    }

    IEnumerator ChangeState()
    {
        yield return null;
        owner.ChangeState<InitPhaseOneState>();
    }
}
