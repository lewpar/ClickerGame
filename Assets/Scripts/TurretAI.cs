using UnityEngine;

public class TurretAI : MonoBehaviour
{
    [SerializeField]
    private float shootFrequency = 1f;

    [SerializeField]
    private GameObject bulletPrefab;

    private float shootTimer;

    void Update()
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

    private void Shoot(GameObject target)
    {
        Debug.Log("Shooting Turret");
        
        var direction = (target.transform.position - this.transform.position).normalized;

        var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity, this.transform);
        var bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.Direction = direction;
        Debug.Log(direction);
    }

    GameObject GetClosestZombie()
    {
        GameObject closest = null;
        float closestDistance = 0f;

        foreach(var zombie in GameState.Instance.Zombies)
        {
            if(closest is null)
            {
                closest = zombie;
                closestDistance = Vector2.Distance(this.transform.position, zombie.transform.position);
                continue;
            }

            var distance = Vector2.Distance(this.transform.position, zombie.transform.position);
            if(distance < closestDistance)
            {
                closest = zombie;
            }
        }

        return closest;
    }
}
