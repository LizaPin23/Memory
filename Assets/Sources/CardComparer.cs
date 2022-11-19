using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComparer : MonoBehaviour
{   
    public bool Compare(Card cardOne, Card cardTwo)
    {
        bool result = cardOne.ID == cardTwo.ID;

        if(result == true)
        {
            cardOne.HideCard();
            cardTwo.HideCard();
        }
        else
        {
            cardOne.SetRevealed(false);
            cardTwo.SetRevealed(false);
        }

        return result;
    }
}
