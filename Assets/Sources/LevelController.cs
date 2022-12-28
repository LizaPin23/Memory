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
    [SerializeField] private GameFinishMenu _gameFinishMenu;

    public event Action GameFinish;

    private Score _score;

    private void Awake()
    {
        _score = new Score(_levelConfig.RightAnswerScore, _levelConfig.WrongAnswerScore);
        _score.ScoreEvent += _scoreText.OnShowScoreText;
        _scoreText.OnShowScoreText(_score.Value);
        _cards.CardComparisonStarted += DisableInput;
        _cards.CardsCompared += OnCardsCompared;
        _cards.AllCardsMatched += FinishGame;
        GameFinish += _gameFinishMenu.Show;

        ActivateInput();
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _cards.CreateCards(_levelConfig);
        _score.NullScore();
        _gameFinishMenu.Hide();
    }

    public void FinishGame()
    {
        _cards.DeleteCards();
        _gameFinishMenu.SetFinalScore(_score.Value);
        GameFinish?.Invoke();
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
