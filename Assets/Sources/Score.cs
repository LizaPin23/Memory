using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private int _score;
    public event Action<int> ScoreEvent;



    public void Increase(int score)
    {
        if (score < 0)
        {
            return;
        }

        _score += score;
        ScoreEvent?.Invoke(score);
    }

    public bool TryDecrease(int score)
    {
        if (score < 0)
        {
            Debug.LogError("Wrong value");
            return false;
        }

        if (_score < score)
        {
            _score = 0;
            ScoreEvent?.Invoke(score);
            return false;
        }

        _score -= score;
        ScoreEvent?.Invoke(score);
        return true;
    }
}
