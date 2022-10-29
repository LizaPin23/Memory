using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private CardFactory _factory;
    [SerializeField] private LevelConfig _levelConfig;

    private void Start()
    {
        CreateLevel(_levelConfig);
    }

    public void CreateLevel(LevelConfig config)
    {
        for (int i = 0; i < config.Cards.Length; i++)
        {
            for (int j = 0; j < config.CardsOfSameType; j++)
            {
                _factory.Create(config.Cards[i], Vector3.zero);
            }
        }
    }
}
