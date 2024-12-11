using UnityEngine;

public class GridUnit : MonoBehaviour
{
    public SpatialGridCell CurrentCell { get; set; }

    public virtual void OnAwake() { }
    void Awake() => OnAwake();

    public virtual void OnStart() { }
    void Start() => OnStart();

    public virtual void OnUpdate() { }
    void Update() => OnUpdate();

    public virtual void OnFixedUpdate() 
    { 
        UpdateCell();
    }
    void FixedUpdate() => OnFixedUpdate();

    private void UpdateCell()
    {
        var world = WorldController.Instance;
        var cell = world.GetCell(this.transform.position);

        if(CurrentCell == null)
        {
            CurrentCell = cell;
            Debug.Log($"Unit {this.gameObject.name} freshly added to cell {CurrentCell.Cell}.");
        }

        if(cell != CurrentCell)
        {
            CurrentCell?.Remove(this);
            cell.Add(this);
            CurrentCell = cell;
            Debug.Log($"Unit {this.gameObject.name} changed cells {CurrentCell.Cell}.");
        }
    }
}
