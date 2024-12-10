using UnityEngine;

public class ZombieEmitterScript : MonoBehaviour
{
    [SerializeField]
    private float spawnFrequency = 1f;

    [SerializeField]
    private GameObject zombiePrefab;

    private float timePassed;

    void Start()
    {
        if(zombiePrefab is null)
        {
            throw new System.Exception($"Failed to get zombie prefab for zombie emitter script on object {this.name}");
        }
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > spawnFrequency)
        {
            timePassed = 0;

            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        var variation = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
        var position = this.transform.position + variation;
        var zombie = GameObject.Instantiate(zombiePrefab, position, Quaternion.identity, this.transform);
        GameState.Instance.Zombies.Add(zombie);
    }
}
