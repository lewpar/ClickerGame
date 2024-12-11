using System.Collections.Generic;

using UnityEngine;

public class SpatialGrid
{
    public int CellSize { get; private set; }

    public Dictionary<Vector2Int, SpatialGridCell> Cells { get; private set; }

    public SpatialGrid(int cellSize = 4)
    {
        CellSize = cellSize;
        Cells = new Dictionary<Vector2Int, SpatialGridCell>();
    }

    public SpatialGridCell GetCell(float x, float y)
    {
        var gridPosition = new Vector2Int(Mathf.FloorToInt(x / CellSize), Mathf.FloorToInt(y / CellSize));

        if(!Cells.ContainsKey(gridPosition))
        {
            var newCell = new SpatialGridCell();
            Cells.Add(gridPosition, newCell);
            newCell.Grid = this;
            newCell.Cell = gridPosition;
            return newCell;
        }

        return Cells[gridPosition];
    }

    public SpatialGridCell GetCell(Vector2 position)
    {
        return GetCell(position.x, position.y);
    }
}