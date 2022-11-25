using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTextView : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void ShowScoreText(int _score)
    {
        _text.text = _score.ToString();
    }
        
}
