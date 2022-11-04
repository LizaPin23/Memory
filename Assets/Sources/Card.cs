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
    private string _iD;
    public event Action ChangeCard;


    private void Awake()
    {
        _clickHandler.Clicked += OnClick;
    }

    public void Initialize(CardConfig config)
    {
        _renderer.sprite = config.photo;
        _iD = config.iD;
        _effect.Play();
        SetRevealed(false);
    }

    private void OnClick()
    {
        SetRevealed(true);
       //ChangeCard?.Invoke();

        if()
        {

        }
    }

    private void SetRevealed(bool value)
    {
        _rendererCardBack.enabled =!value;
    }
}
