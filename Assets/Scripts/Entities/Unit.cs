using UnityEngine;

public abstract class Unit : GridUnit
{
    public UnitAI AI { get; set; }

    public override void OnAwake()
    {
        if(AI != null)
        {
            AI.Awake();
        }
    }

    public override void OnUpdate()
    {
        if(AI != null)
        {
            AI.Update();
        }
    }

    public override void OnFixedUpdate()
    {
        if(AI != null)
        {
            AI.FixedUpdate();
        }

        // Needed for cell updates
        base.OnFixedUpdate();
    }

    public void DestroySafe()
    {
        CurrentCell.Remove(this);
        Destroy(this.gameObject);
    }
}
