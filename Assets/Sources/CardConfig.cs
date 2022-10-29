using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardConfig", menuName = "Memory/CardConfigs")]
public class CardConfig : ScriptableObject 
{
    [SerializeField] private Sprite _photo;
    [SerializeField] private string _iD;

    public Sprite photo => _photo;
    public string iD => _iD;
}
