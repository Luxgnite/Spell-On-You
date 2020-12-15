using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MixCard : MonoBehaviour
{ 

    public void Mix()
    {
        // Insert cards at random order into the shuffled list 
        var Mix = new List<Card>();
        var rand = new System.Random();
        var Temp = new List<Card>();

        // As long as there are any cards left to insert randomly 
        while (Mix.Count != 0)
        {
            // Get the index of the random card to insert 
            var i = rand.Next(Mix.Count);

            // Insert it 
            Temp.Add(Mix[i]);

            // Remove from non-shuffled list 
            Mix.RemoveAt(i);
        }

        // Set the list of cards to the shuffled list 
        Mix = Temp;
    }

}
