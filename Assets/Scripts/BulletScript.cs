using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector2 Direction { get; set; } = Vector2.zero;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float lifetime = 1f;

    private float currentLifetime;

    [SerializeField]
    private AudioClip[] popSounds;

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

        this.transform.position += (Vector3)Direction * moveSpeed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var gameObject = other.gameObject;

        var zombie = gameObject.GetComponent<Zombie>();
        if(zombie is null)
        {
            return;
        }

        zombie.DestroySafe();
        GameObject.Destroy(this.gameObject);
        GameState.Instance.UpdateGold(1);

        AudioSource.PlayClipAtPoint(GetRandomPopSound(), Camera.main.transform.position, 0.10f);
    }

    private AudioClip GetRandomPopSound()
    {
        return popSounds[Random.Range(0, popSounds.Length - 1)];
    }
}
