using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    private PlayerController playerScript;

    [SerializeField]
    private float moveSpeed = 2;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        playerScript = GameObject.FindAnyObjectByType<PlayerController>();
        if(playerScript is null)
        {
            throw new System.Exception($"Failed to get player controller script for zombie ai script on object {this.name}");
        }

        rigidBody = this.GetComponent<Rigidbody2D>();
        if(rigidBody is null)
        {
            throw new System.Exception($"Failed to get rigidbody2d for zombie ai script on object {this.name}");
        }
    }

    private void FixedUpdate()
    {
        if(!playerScript.IsAlive)
        {
            return;
        }

        rigidBody.velocity = Vector2.zero;

        var direction = (playerScript.gameObject.transform.position - this.transform.position).normalized;

        rigidBody.velocity = (direction * moveSpeed).normalized * moveSpeed;
    }

    private void Update()
    {
        if(!playerScript.IsAlive)
        {
            return;
        }

        var distanceToPlayer = Vector2.Distance(playerScript.gameObject.transform.position, this.transform.position);
        if(distanceToPlayer < 0.5f)
        {
            playerScript.Kill();
        }
    }

    public void Kill()
    {
        GameState.Instance.Zombies.Remove(this.gameObject);
        GameObject.Destroy(this.gameObject);
    }
}
