using UnityEngine;

public class TurretAI : GridUnit
{
    [SerializeField]
    private float shootFrequency = 1f;

    [SerializeField]
    private GameObject bulletPrefab;

    private float shootTimer;

    public override void OnUpdate()
    {
        var closestZombie = GetClosestZombie();
        if(closestZombie is null)
        {
            return;
        }

        var direction = (closestZombie.transform.position - this.transform.position).normalized;
        var rotation = Quaternion.LookRotation(direction, Vector3.forward);

        this.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        shootTimer += Time.deltaTime;

        if(shootTimer > shootFrequency)
        {
            Shoot(closestZombie);
            shootTimer = 0f;
        }
    }

    private void Shoot(Unit target)
    {
        Debug.Log("Shooting Turret");
        
        var direction = (target.transform.position - this.transform.position).normalized;

        var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity, this.transform);
        var bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.Direction = direction;
        Debug.Log(direction);
    }

    Zombie GetClosestZombie()
    {
        var cells = CurrentCell.GetAdjacentCells();

        Zombie closestZombie = null;
        float closestDistance = float.MaxValue;
        
        foreach(var cell in cells)
        {
            foreach(var unit in cell.Units)
            {
                if(unit is not Zombie)
                {
                    continue;
                }

                var distance = Vector2.Distance(this.transform.position, unit.transform.position);

                if(closestZombie is null)
                {
                    closestZombie = unit as Zombie;
                    closestDistance = distance;
                    continue;
                }

                if(distance < closestDistance)
                {
                    closestZombie = unit as Zombie;
                }
            }
        }

        return closestZombie;
    }
}
