using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTextView : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void OnShowScoreText(int score)
    {
        _text.text = score.ToString();
    }
        
}
