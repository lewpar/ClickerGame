using UnityEngine;

public abstract class UnitAI
{
    public Unit Unit { get; set; }
    public Rigidbody2D Rigidbody { get; private set; }

    public UnitAI(Unit unit)
    {
        this.Unit = unit;
    }

    public virtual void Awake()
    {
        Rigidbody = Unit.GetComponent<Rigidbody2D>();
    }

    public abstract void Update();
    public abstract void FixedUpdate();

    public void Move(Vector2 direction)
    {
        Rigidbody.velocity = direction;
    }

    public void StopMove()
    {
        Rigidbody.velocity = Vector2.zero;
    }
}
