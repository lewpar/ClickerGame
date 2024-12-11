using UnityEngine;

public class ZombieAI : UnitAI
{
    public ZombieAI(Unit unit) : base(unit) {}

    public override void Update()
    {
        var player = GameState.Player;
        if(player == null)
        {
            return;
        }

        if(!player.IsAlive)
        {
            return;
        }

        var distanceToPlayer = Vector2.Distance(player.gameObject.transform.position, this.Unit.transform.position);

        if(distanceToPlayer < 0.51f)
        {
            player.Kill();
        }
    }

    public override void FixedUpdate()
    {
        this.StopMove();

        var player = GameState.Player;
        if(player == null)
        {
            return;
        }

        if(!player.IsAlive)
        {
            return;
        }

        var direction = (player.gameObject.transform.position - this.Unit.transform.position).normalized;
        this.Move(direction);
    }
}
