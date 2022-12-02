using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public int Value { get; private set; }
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
        Value += _rightAnswerScore;
        ScoreEvent?.Invoke(Value);
    }

    public bool TryDecrease()
    {
        if (Value < _wrongAnswerScore)
        {
            Value = 0;
            ScoreEvent?.Invoke(Value);
            return false;
        }

        Value -= _wrongAnswerScore;
        ScoreEvent?.Invoke(Value);
        return true;
    }
}
