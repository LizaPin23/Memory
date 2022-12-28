using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] private CardFactory _factory;
    [SerializeField] private Vector2 _offset = new Vector2(2f, 3f);
    [SerializeField] private int _colsCount = 4;

    public event Action<bool> CardsCompared;
    public event Action CardComparisonStarted;
    public event Action AllCardsMatched;

    private CardComparer _comparer;
    private List<Card> _cards;
    private SoundController _soundController;
    private int _parsOnSc;

    public void CreateCards(LevelConfig config, SoundController soundController)
    {
        _comparer = new CardComparer(config.CardRevealDelay);
        _cards = new List<Card>();
        _soundController = soundController;
        _comparer.CardsCompared += OnCardsCompared;

        int cardsCount = config.Cards.Length * config.CardsOfSameType;

        CardsGrid grid = new CardsGrid(cardsCount, _colsCount, _offset);
        for (int i = 0; i < config.Cards.Length; i++)
        {
            for (int j = 0; j < config.CardsOfSameType; j++)
            {
                Card card = _factory.Create(config.Cards[i], grid);
                _cards.Add(card);
                card.Clicked += OnCardSelected;
            }
        }

        _parsOnSc = _cards.Count / 2;
    }

    private void OnCardSelected(Card card)
    {
        card.SetRevealed(true);
        _soundController.ClickSound();

        if (_comparer.HasCard)
        {
            CardComparisonStarted?.Invoke();
            StartCoroutine(_comparer.Compare(card));
        }
        else
        {
            _comparer.RememberCard(card);
        }
    }

    private void OnCardsCompared(bool value)
    {
        CardsCompared?.Invoke(value);
        if(value == true)
        {
            _parsOnSc--;
            if(_parsOnSc == 0)
            {
                AllCardsMatched?.Invoke();
            }
        }

    }

    public void DeleteCards()
    {
        int cardsCount = _cards.Count;

        for (int i = 0; i < cardsCount; i++)
        {
            Destroy(_cards[i].gameObject);
        }

        _cards.Clear();
    }
}
