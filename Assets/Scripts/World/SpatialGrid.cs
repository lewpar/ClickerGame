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
}