using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] private CardFactory _factory;
    [SerializeField] private Vector2 _offset = new Vector2(2f, 3f);
    [SerializeField] private int _colsCount = 4;

    private CardComparer _comparer;
    private List<Card> _cards;

    public void CreateCards(LevelConfig config)
    {
        int cardsCount = config.Cards.Length * config.CardsOfSameType;

        CardsGrid grid = new CardsGrid(cardsCount, _colsCount, _offset);
        for (int i = 0; i < config.Cards.Length; i++)
        {
            for (int j = 0; j < config.CardsOfSameType; j++)
            {
                _factory.Create(config.Cards[i], grid);
            }
        }

        _comparer = new CardComparer();
    }
}
