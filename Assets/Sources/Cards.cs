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

    private CardComparer _comparer;
    private List<Card> _cards;

    public void CreateCards(LevelConfig config)
    {
        _comparer = new CardComparer();
        _cards = new List<Card>();
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
    }

    private void OnCardSelected(Card card)
    {
        _comparer.OpenCard(card);
    }

    private void OnCardsCompared(bool value)
    {
        CardsCompared?.Invoke(value);
    }
}
