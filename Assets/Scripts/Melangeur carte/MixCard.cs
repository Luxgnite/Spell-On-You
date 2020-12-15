using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityEngine.UI;


public class MixCard : MonoBehaviour
{ 

    public void Mix()
    {
        // Insert cards at random order into the shuffled list 
        var Mix = new List<Card>();
        var rand = new Random();

        // As long as there are any cards left to insert randomly 
        while (MixCard.Count != 0)
        {
            // Get the index of the random card to insert 
            var i = rand.Next(MixCard.Count);

            // Insert it 
            Mixed.Add(kaarten[i]);

            // Remove from non-shuffled list 
            MixCard.RemoveAt(i);
        }

        // Set the list of cards to the shuffled list 
        MixCard = Mixed;
    }
}
