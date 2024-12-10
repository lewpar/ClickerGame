using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector2 Direction { get; set; } = Vector2.zero;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float lifetime = 1f;

    private float currentLifetime;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        if(rigidBody is null)
        {
            throw new System.Exception($"Failed to get rigidbody2d for bullet script on object {this.name}");
        }
    }

    void Update()
    {
        currentLifetime += Time.deltaTime;
        if(currentLifetime > lifetime)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if(Direction == Vector2.zero)
        {
            return;
        }

        rigidBody.velocity = Direction * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var gameObject = other.gameObject;

        var zombieAI = gameObject.GetComponent<ZombieAI>();
        if(zombieAI is null)
        {
            return;
        }

        zombieAI.Kill();
        GameObject.Destroy(this.gameObject);
        GameState.Instance.UpdateGold(1);
    }
}
