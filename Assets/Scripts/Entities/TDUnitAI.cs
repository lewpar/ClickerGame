using UnityEngine;

public class TDUnitAI : UnitAI
{
    private int currentPath = 1;
    public Transform[] Path { get; set; }

    public TDUnitAI(Unit unit) : base(unit) { }

    public override void FixedUpdate()
    {
        if(GameState.Instance.GameLost)
        {
            return;
        }
        
        if(Path == null)
        {
            return;
        }
        
        if(currentPath >= Path.Length)
        {
            this.Unit.DestroySafe(playSound: true, rewardGold: false);
            AudioSource.PlayClipAtPoint(this.Unit.GetRandomDamageSound(), Camera.main.transform.position, 0.25f);
            GameState.Instance.UpdateLife(-this.Unit.GetLifeDamage());
            return;
        }

        var currentPosition = this.Unit.transform.position;
        var targetPosition = Path[currentPath].position;

        if(Vector2.Distance(currentPosition, targetPosition) < 0.1)
        {
            currentPath += 1;
        }
        else
        {
            var direction = (targetPosition - currentPosition).normalized;
            this.Unit.transform.position = currentPosition + direction * Time.fixedDeltaTime;
        }
    }

    public override void Update() { }
}
