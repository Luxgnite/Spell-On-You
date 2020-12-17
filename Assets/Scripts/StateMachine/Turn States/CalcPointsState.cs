using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcPointsState : TurnState
{
    public override void Enter()
    {
        base.Enter();
        gameManager.User.ConvertGemmesIntoFollowers();
        StartCoroutine(ChangeState());
    }

    IEnumerator ChangeState()
    {
        yield return null;
        owner.ChangeState<EndPhaseThreeState>();
    }
}
