using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private int _score;
    private int _rightAnswerScore;
    private int _wrongAnswerScore;
    public event Action<int> ScoreEvent;

    public Score(int rightAnswerScore, int wrongAnswerScore)
    {
        _rightAnswerScore = rightAnswerScore;
        _wrongAnswerScore = wrongAnswerScore;
    }


    public void Increase()
    {
        _score += _rightAnswerScore;
        ScoreEvent?.Invoke(_score);
    }

    public bool TryDecrease()
    {
        if (_score < _wrongAnswerScore)
        {
            _score = 0;
            ScoreEvent?.Invoke(_score);
            return false;
        }

        _score -= _wrongAnswerScore;
        ScoreEvent?.Invoke(_score);
        return true;
    }
}
