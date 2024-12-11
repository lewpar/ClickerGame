using UnityEngine;

public class WorldController : MonoBehaviour
{
    public static WorldController Instance { get; private set; }

    public SpatialGrid Grid { get; set; }

    [SerializeField]
    private bool drawGrid;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Grid = new SpatialGrid(4);
    }

    public SpatialGridCell GetCell(Vector2 position)
    {
        var gridPosition = new Vector2Int(Mathf.FloorToInt(position.x / Grid.CellSize), Mathf.FloorToInt(position.y / Grid.CellSize));

        if(!Grid.Cells.ContainsKey(gridPosition))
        {
            var newCell = new SpatialGridCell();
            Grid.Cells.Add(gridPosition, newCell);
            newCell.Cell = gridPosition;
            return newCell;
        }

        return Grid.Cells[gridPosition];
    }

    private void OnDrawGizmos()
    {
        if(drawGrid && Grid != null)
        {
            bool flipColor = false;

            foreach(var cell in Grid.Cells.Values)
            {
                flipColor = !flipColor;

                Gizmos.color = flipColor ? Color.red : Color.green;
                Gizmos.DrawCube(new Vector3((cell.Cell.x + 0.5f) * Grid.CellSize, (cell.Cell.y + 0.5f) * Grid.CellSize, 0), new Vector3(Grid.CellSize, Grid.CellSize, 0));
            }
        }
    }
}
