using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Cards _cards;
    [SerializeField] private CardComparer _cardComparer;
    [SerializeField] private ScoreTextView _scoreText;
    [SerializeField] private Physics2DRaycaster _mainRaycaster;
    //public event Action<bool> GameFinish;

    private Score _score;

    private void Awake()
    {
        _score = new Score(_levelConfig.RightAnswerScore, _levelConfig.WrongAnswerScore);
        _score.ScoreEvent += _scoreText.OnShowScoreText;
        _scoreText.OnShowScoreText(_score.Value);
        _cards.CardComparisonStarted += DisableInput;
        _cards.CardsCompared += OnCardsCompared;
        ActivateInput();
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _cards.CreateCards(_levelConfig);
    }

    public void FinishGame()
    {
        _cards.DeleteCards();
        //GameFinish?.Invoke(true);
    }

    private void OnCardsCompared(bool value)
    {
        ActivateInput();

        if (value)
        {
            _score.Increase();
        }
        else
        {
            _score.TryDecrease();
        }
    }

    private void ActivateInput()
    {
        _mainRaycaster.enabled = true;
    }

    private void DisableInput()
    {
        _mainRaycaster.enabled = false;
    }
}
