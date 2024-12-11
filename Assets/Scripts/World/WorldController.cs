using UnityEditor;
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

    private void OnDrawGizmos()
    {
        if(drawGrid && Grid != null)
        {
            bool flipColor = false;

            foreach(var cell in Grid.Cells.Values)
            {
                flipColor = !flipColor;

                Gizmos.color = flipColor ? Color.red : Color.green;

                var cellPosition = new Vector3((cell.Cell.x) * Grid.CellSize, (cell.Cell.y) * Grid.CellSize, 0);
                var textPosition = new Vector3((cell.Cell.x) * Grid.CellSize, (cell.Cell.y + 0.5f) * Grid.CellSize, 1);

                Handles.DrawSolidRectangleWithOutline(new Rect(cellPosition.x, cellPosition.y, Grid.CellSize, Grid.CellSize), Color.red, Color.green);
                Handles.Label(textPosition, $"Cell {cell.Cell}");
            }
        }
    }
}
