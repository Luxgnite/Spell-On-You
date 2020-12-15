using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTurnState : TurnState
{
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return null;
        //Changer par le prochain State
        owner.ChangeState<InitPhaseOneState>();
    }
}
