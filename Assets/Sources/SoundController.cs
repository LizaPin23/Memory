using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private AudioSource _anwserSound;
    [SerializeField] private AudioClip _wrongSound;
    [SerializeField] private AudioClip _rightSound;


    public void WrongAnwser()
    {
        _anwserSound.clip = _wrongSound;
        _anwserSound.Play();
    }
    public void RightAnwser()
    {
        _anwserSound.clip = _rightSound;
        _anwserSound.Play();
    }
    public void ClickSound()
    {
        _clickSound.Play();
    }
}
