using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePictureCardState : TurnState
{
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
