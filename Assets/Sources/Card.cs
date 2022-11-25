using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private ParticleSystem _effect;
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
        _effect.Play();
    }

    public void SetRevealed(bool value)
    {
        _rendererCardBack.enabled =!value;
    }

    public void HideCard()
    {
        gameObject.SetActive(false);
    }
}
