using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPhaseOneState : TurnState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(ChangeState());
    }

    IEnumerator ChangeState()
    {
        yield return null;
        owner.ChangeState<CreatePostState>();
    }
}
