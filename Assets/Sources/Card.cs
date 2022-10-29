using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private SpriteRenderer _renderer;
    public event Action ChangeCard;


    private void Awake()
    {
        _clickHandler.Clicked += OnClick;
    }

    public void Initialize(CardConfig config)
    {
        _renderer.sprite = config.photo;
    }

    private void OnClick()
    {
        Debug.Log("Карточка нажата");
       // ChangeCard?.Invoke();
    }
}
