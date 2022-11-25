using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Cards _cards;
    private Score _score;
    [SerializeField] private CardComparer _cardComparer;

    private void Awake()
    {
        //_score.ScoreEvent += ScoreResult;
    }

    

    private void Start()
    {
        _cards.CreateCards(_levelConfig);
        _cards.CardsCompared += OnCardsCompared;
        _score = new Score(_levelConfig.RightAnswerScore , _levelConfig.WrongAnswerScore);
        
    }

    //public int ScoreResult(int score)
    //{
    //    //Debug.Log(score);
    //}

    private void OnCardsCompared(bool value)
    {
        if (value)
        {
            _score.Increase();
        }
        else
        {
            _score.TryDecrease();
        }
    }
}
