using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
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

    public bool Decrease(int score)
    {
        if (score < 0)
        {
            Debug.LogError("Wrong value");
            return false;
        }

        if (_score < score)
        {
            return false;
        }

        _score -= score;
        ScoreEvent?.Invoke(score);
        return true;
    }
}
