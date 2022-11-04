using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    [SerializeField] private Card _template;
    [SerializeField] private Transform _root;

    public Card Create(CardConfig config, CardsGrid grid)
    {
        Card card = Instantiate(_template, _root);

        card.Initialize(config);
        card.transform.position = grid.GetRandomPosition();

        return card;
    }
}
