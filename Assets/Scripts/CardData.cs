using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Thematique
{
    Mode,
    Voyage,
    Sport,
    Animaux,
    Nourriture,
    Automoto
}

public enum Categorie
{
    Photo,
    Description,
    Hashtag,
    Lieu
}

[CreateAssetMenu( fileName = "NewCardData", menuName = "Card Data")]
public class CardData : ScriptableObject
{
    public string cardName;
    public string text;
    public Sprite illustration;

    public Categorie categorie;
    public Thematique theme;
    public int nbCoeur = 1;
}
