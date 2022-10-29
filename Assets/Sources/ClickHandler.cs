using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public event Action Clicked;
    [SerializeField] public Card _card;

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
        //_card.OnClick();
    }
}
