using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Cards _cards;
    [SerializeField] private Score _score;


    private void Start()
    {
        _cards.CreateCards(_levelConfig);
    }


}
