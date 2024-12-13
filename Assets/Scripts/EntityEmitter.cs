using UnityEngine;

public class EntityEmitterScript : MonoBehaviour
{
    [SerializeField]
    private float spawnFrequency = 1f;

    [SerializeField]
    private GameObject entityPrefab;

    private float timePassed;

    void Start()
    {
        if(entityPrefab is null)
        {
            throw new System.Exception($"Failed to get entity prefab for entity emitter script on object {this.name}");
        }
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > spawnFrequency)
        {
            timePassed = 0;

            SpawnEntity();
        }
    }

    private void SpawnEntity()
    {
        var variation = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
        var position = this.transform.position + variation;
        var entity = GameObject.Instantiate(entityPrefab, position, Quaternion.identity, this.transform);
        GameState.Instance.Zombies.Add(entity);
    }
}
