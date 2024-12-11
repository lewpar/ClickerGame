using System.Collections.Generic;

using UnityEngine;

public class SpatialGridCell
{
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
}
