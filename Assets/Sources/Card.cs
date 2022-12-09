using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private ParticleSystem _rightChoiceEffect;
    [SerializeField] private ParticleSystem _wrongChoiceEffect;
    [SerializeField] private CardAnimator _animator;
    [SerializeField] private SpriteRenderer _photoRenderer;

    public string ID { get; private set; }
    public event Action<Card> Clicked;

    private void Awake()
    {
        _clickHandler.Clicked += OnClick;
    }

    public void Initialize(CardConfig config)
    {
        _photoRenderer.sprite = config.photo;
        ID = config.iD;
        SetRevealed(false);
        _animator.SetVisible(true);
    }

    private void OnClick()
    {
        Clicked?.Invoke(this);
    }

    public void SetRevealed(bool value)
    {
        _animator.SetRevealed(value);
    }

    public void HideCard()
    {
        _animator.SetVisible(false);
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
