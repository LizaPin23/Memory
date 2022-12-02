using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComparer
{
    public event Action<bool> CardsCompared;
    private Card _lastOpenedCard;
    private float _revealDelay;

    public CardComparer(float revealDelay)
    {
        _revealDelay = revealDelay;
    }

    public bool HasCard => _lastOpenedCard != null;

    public void RememberCard(Card card)
    {
        _lastOpenedCard = card;
    }

    public IEnumerator Compare(Card nextCard)
    {
        yield return new WaitForSeconds(_revealDelay);

        bool result = _lastOpenedCard.ID == nextCard.ID;

        if(result == true)
        {
            _lastOpenedCard.HideCard();
            nextCard.HideCard();
            _lastOpenedCard.OnRightChoice();
            nextCard.OnRightChoice();
        }
        else
        {
            _lastOpenedCard.SetRevealed(false);
            nextCard.SetRevealed(false);
            _lastOpenedCard.OnWrongChoice();
            nextCard.OnWrongChoice();
        }

        CardsCompared?.Invoke(result);
        _lastOpenedCard = null;
    }
}
