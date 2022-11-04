using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsGrid
{
    private readonly List<Vector2> _positions;

    public CardsGrid(int cardsCount, Vector2 offset)
    {
        _positions = new List<Vector2>(cardsCount);

        Vector2 basePosition = GetBasePosition(cardsCount, offset);
        CreateRow(basePosition.x, cardsCount, offset.x, basePosition.y);
    }

    private Vector2 GetBasePosition(int cardsCount, Vector2 offset)
    {
        float evenOffset = offset.x / 2 * (1 - cardsCount % 2);
        float baseX = -offset.x * cardsCount / 2 - evenOffset;

        //TODO y 

        return new Vector2(baseX, 0);
    }

    private void CreateRow(float baseX, int cardsInRow, float offset, float y)
    {
        for(int i = 0; i < cardsInRow; i++)
        {
            _positions.Add(new Vector2(baseX, y));
            baseX += offset;
        }
    }


    public Vector2 GetRandomPosition()
    {
        int index = Random.Range(0, _positions.Count);
        Vector2 result = _positions[index];
        _positions.RemoveAt(index);
        return result;
    }
}
