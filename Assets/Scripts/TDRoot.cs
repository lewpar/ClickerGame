using UnityEngine;

public class TDRoot : MonoBehaviour
{
    [SerializeField]
    private float spawnFrequency = 1f;

    [SerializeField]
    private GameObject entityPrefab;

    private float timePassed;

    [SerializeField]
    private Transform[] path;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Transform previousNode = null;
        foreach(var node in path)
        {
            if(previousNode == null)
            {
                previousNode = node;
                continue;
            }

            Gizmos.DrawLine(previousNode.position, node.position);
            previousNode = node;
        }
    }

    private void Start()
    {
        if(entityPrefab is null)
        {
            throw new System.Exception($"Failed to get entity prefab for entity emitter script on object {this.name}");
        }

        if(path == null || path.Length == 0)
        {
            throw new System.Exception($"No path setup on TDRoot on object {this.name}.");
        }
    }

    private void Update()
    {
        if(GameState.Instance.GameLost)
        {
            return;
        }
        
        timePassed += Time.deltaTime;
        if(timePassed > spawnFrequency)
        {
            timePassed = 0;

            SpawnEntity();
        }
    }

    private void SpawnEntity()
    {
        var startPosition = path[0].position;

        var entity = GameObject.Instantiate(entityPrefab, startPosition, Quaternion.identity, null);

        var unit = entity.GetComponent<TDUnit>();
        if(unit == null)
        {
            return;
        }

        var ai = unit.AI as TDUnitAI;
        if(ai == null)
        {
            return;
        }

        ai.Path = path;
    }
}
