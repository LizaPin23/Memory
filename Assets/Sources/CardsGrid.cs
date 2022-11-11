using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsGrid
{
    private readonly List<Vector2> _positions;

    public CardsGrid(int cardsCount, int colsCount, Vector2 offset)
    {
        _positions = new List<Vector2>(cardsCount);

        int rowsCount = cardsCount / colsCount;
        int colsInExtraRow = cardsCount % colsCount;

        if (colsInExtraRow != 0)
            rowsCount++;

        Vector2 basePosition = GetBasePosition(rowsCount, colsCount, offset);

        for(int i = 0; i < rowsCount; i++)
        {
            float positionY = basePosition.y - offset.y * i;
            CreateRow(basePosition.x, colsCount, offset.x, positionY);
        }
    }

    private Vector2 GetBasePosition(int rowsCount, int colsCount, Vector2 offset)
    {
        
        float evenOffsetX = offset.x / 2 * (1 - colsCount % 2);
        float baseX = -offset.x * colsCount / 2 + evenOffsetX;

        float evenOffsetY = offset.y / 2 * (1 - rowsCount % 2);
        float baseY = offset.y * rowsCount / 2 - evenOffsetY;


        return new Vector2(baseX, baseY);
    }

    private void CreateRow(float baseX, int cardsInRow, float offset, float baseY)
    {
        for(int i = 0; i < cardsInRow; i++)
        {
            _positions.Add(new Vector2(baseX, baseY));
            baseX += offset;
        }
    }

    private void CreateColumn()
    {

    }


    public Vector2 GetRandomPosition()
    {
        int index = Random.Range(0, _positions.Count);
        Vector2 result = _positions[index];
        _positions.RemoveAt(index);
        return result;
    }
}
