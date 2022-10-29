using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Memory/LevelConfig", fileName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _cardsOfSameType = 2;
    [SerializeField] private CardConfig[] _cards;

    public int CardsOfSameType => _cardsOfSameType;
    public CardConfig[] Cards => _cards;

}
