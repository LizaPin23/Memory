using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsGrid
{
    private readonly List<Vector2> _positions;

    public CardsGrid(int cardsCount, Vector2 offset)
    {
        _positions = new List<Vector2>(cardsCount);

    }

    private void ConfigureGrid(int cardsCount, Vector2 offset)
    {
        float evenOffset = offset.x / 2 * (1 - cardsCount % 2);
        float baseX = offset.x * cardsCount / 2 + evenOffset;

    }


    public Vector2 GetRandomPosition()
    {
        int index = Random.Range(0, _positions.Count);
        Vector2 result = _positions[index];
        _positions.RemoveAt(index);
        return result;
    }
}
