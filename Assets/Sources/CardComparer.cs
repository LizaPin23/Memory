using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComparer
{
    public event Action<bool> CardsCompared;
    private Card _lastOpenedCard;

    public void OpenCard(Card card)
    {
        if (_lastOpenedCard != null)
        {
            Compare(_lastOpenedCard, card);
            _lastOpenedCard = null;
        }
        else
        {
            card.SetRevealed(true);
            _lastOpenedCard = card;
        }
    }

    private void Compare(Card cardOne, Card cardTwo)
    {
        bool result = cardOne.ID == cardTwo.ID;

        if(result == true)
        {
            cardOne.HideCard();
            cardTwo.HideCard();
            cardOne.OnRightChoice();
            cardTwo.OnRightChoice();
        }
        else
        {
            cardOne.SetRevealed(false);
            cardTwo.SetRevealed(false);
            cardOne.OnWrongChoice();
            cardTwo.OnWrongChoice();
        }

        CardsCompared?.Invoke(result);
    }
}
