using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;

    private void Awake()
    {
        _clickHandler.Clicked += OnClick;
    }

    private void OnClick()
    {
        Debug.Log("Карточка нажата");
    }
}
