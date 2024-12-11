using System.Collections.Generic;

using UnityEngine;

public class SpatialGridCell
{
    public SpatialGrid Grid { get; set; }
    public Vector2Int Cell { get; set; }
    public HashSet<GridUnit> Units { get; set; }

    public SpatialGridCell()
    {
        Units = new HashSet<GridUnit>();
    }

    public void Add(GridUnit unit)
    {
        Units.Add(unit);
    }

    public void Remove(GridUnit unit)
    {
        Units.Remove(unit);
    }

    public SpatialGridCell[] GetAdjacentCells()
    {
        return new SpatialGridCell[9]
        {
            this, // Current Cell (Center)
            Grid.GetCell(Cell.x, Cell.y + 1),     // Top Cell
            Grid.GetCell(Cell.x - 1, Cell.y + 1), // Top Left Cell
            Grid.GetCell(Cell.x + 1, Cell.y + 1), // Top Right Cell
            Grid.GetCell(Cell.x, Cell.y - 1),     // Bottom Cell
            Grid.GetCell(Cell.x - 1, Cell.y - 1), // Bottom Left Cell
            Grid.GetCell(Cell.x + 1, Cell.y - 1), // Bottom Right Cell
            Grid.GetCell(Cell.x - 1, Cell.y),     // Left Cell
            Grid.GetCell(Cell.x + 1, Cell.y)      // Right Cell
        };
    }
}
