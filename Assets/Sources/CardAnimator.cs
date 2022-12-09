using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animatorCard;
    [SerializeField] private string _boolName;

    public void Idle()
    {
        _animatorCard.SetBool(_boolName, false);
    }

    public void Perevorot1()
    {
        _animatorCard.SetBool(_boolName, true);
    }

    public void Perevorot2()
    {
        _animatorCard.SetBool(_boolName, false);
    }
}
