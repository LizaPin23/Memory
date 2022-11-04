using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public event Action Clicked;
   // [SerializeField] private ParticleSystem _effect;

    public void OnPointerClick(PointerEventData eventData)
    {
        //_effect.Play();
        Clicked?.Invoke();
    }
}
