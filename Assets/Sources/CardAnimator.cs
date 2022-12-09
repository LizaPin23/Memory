using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animatorCard;
    [SerializeField] private string _revealedName = "Revealed";
    [SerializeField] private string _visibleName = "Visible";

    public void SetRevealed(bool value)
    {
        _animatorCard.SetBool(_revealedName, value);
    }

    public void SetVisible(bool value)
    {
        _animatorCard.SetBool(_visibleName, value);
    }
}
