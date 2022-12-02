﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private ParticleSystem _rightChoiceEffect;
    [SerializeField] private ParticleSystem _wrongChoiceEffect;

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteRenderer _rendererCardBack;
    public string ID { get; private set; }
    public event Action<Card> Clicked;

    private void Awake()
    {
        _clickHandler.Clicked += OnClick;
    }

    public void Initialize(CardConfig config)
    {
        _renderer.sprite = config.photo;
        ID = config.iD;
        SetRevealed(false);
    }

    private void OnClick()
    {
        Clicked?.Invoke(this);
    }

    public void SetRevealed(bool value)
    {
        _rendererCardBack.enabled =!value;
    }

    public void HideCard()
    {
        _renderer.enabled = false;
        _rendererCardBack.enabled = false;
    }

    public void OnRightChoice()
    {
        _rightChoiceEffect.Play();
    }

    public void OnWrongChoice()
    {
        _wrongChoiceEffect.Play();
    }
}
