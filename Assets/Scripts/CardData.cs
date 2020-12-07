using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "NewCardData", menuName = "Card Data")]
public class CardData : ScriptableObject
{
    public string cardName;
    public string text;
}
