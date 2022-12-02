using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Cards _cards;
    [SerializeField] private CardComparer _cardComparer;
    [SerializeField] private ScoreTextView _scoreText;

    private Score _score;

    private void Awake()
    {
        _score = new Score(_levelConfig.RightAnswerScore, _levelConfig.WrongAnswerScore);
        _score.ScoreEvent += _scoreText.OnShowScoreText;
        _scoreText.OnShowScoreText(_score.Value);
    }

    private void Start()
    {
        _cards.CreateCards(_levelConfig);
        _cards.CardsCompared += OnCardsCompared;
    }

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
