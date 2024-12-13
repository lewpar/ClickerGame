using UnityEngine;

public class TurretAI : Unit
{
    [SerializeField]
    private float shootFrequency = 1f;

    [SerializeField]
    private GameObject bulletPrefab;

    private float shootTimer;

    public TurretAI()
    {
        this.Faction = UnitFaction.Friend;
    }

    public override void OnUpdate()
    {
        var closestEnemy = GetClosestEnemyUnit();
        if(closestEnemy is null)
        {
            return;
        }

        var direction = (closestEnemy.transform.position - this.transform.position).normalized;
        var rotation = Quaternion.LookRotation(direction, Vector3.forward);

        this.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        shootTimer += Time.deltaTime;

        if(shootTimer > shootFrequency)
        {
            Shoot(closestEnemy);
            shootTimer = 0f;
        }
    }

    private void Shoot(Unit target)
    {
        var direction = (target.transform.position - this.transform.position).normalized;

        var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity, null);
        var bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.Direction = direction;
        Debug.Log(direction);
    }

    Unit GetClosestEnemyUnit()
    {
        var cells = CurrentCell.GetAdjacentCells();

        Unit closestUnit = null;
        float closestDistance = float.MaxValue;
        
        foreach(var cell in cells)
        {
            foreach(var cellUnit in cell.Units)
            {
                if(cellUnit is not Unit unit)
                {
                    continue;
                }

                if(unit.Faction != UnitFaction.Enemy)
                {
                    continue;
                }

                var distance = Vector2.Distance(this.transform.position, unit.transform.position);

                if(closestUnit is null)
                {
                    closestUnit = unit;
                    closestDistance = distance;
                    continue;
                }

                if(distance < closestDistance)
                {
                    closestUnit = unit;
                }
            }
        }

        return closestUnit;
    }
}
