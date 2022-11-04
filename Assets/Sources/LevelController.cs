using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private CardFactory _factory;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Vector2 _offset = new Vector2(1f,1f);

    private void Start()
    {
        CreateLevel(_levelConfig);
    }

    public void CreateLevel(LevelConfig config)
    {
        int cardsCount = _levelConfig.Cards.Length * _levelConfig.CardsOfSameType;

        CardsGrid grid = new CardsGrid(cardsCount, _offset);
        for (int i = 0; i < config.Cards.Length; i++)
        {
            for (int j = 0; j < config.CardsOfSameType; j++)
            {
                _factory.Create(config.Cards[i], grid);
            }
        }
    }
}
