using System;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private GameObject bulletPrefab;

    private Rigidbody2D rigidBody;

    private Vector2 movement;

    public bool IsAlive { get; set; }

    public void SetMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    void Start()
    {
        movement = Vector2.zero;
        IsAlive = true;

        rigidBody = this.GetComponent<Rigidbody2D>();
        if(rigidBody is null)
        {
            throw new Exception("Failed to get Rigidbody2D for PlayerController.");
        }

        if(bulletPrefab is null)
        {
            throw new Exception("Failed to get bullet prefab for PlayerController.");
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }

        if(Input.GetKey(KeyCode.S))
        {
            movement -= Vector2.up;
        }

        if(Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }

        if(Input.GetKey(KeyCode.D))
        {
            movement -= Vector2.left;
        }

        // Left Click
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        if(movement == Vector2.zero)
        {
            rigidBody.velocity = Vector2.zero;
            return;
        }

        // Normalize the movement to fix fast diagonal movement
        rigidBody.velocity = (movement * moveSpeed).normalized * moveSpeed;
        movement = Vector2.zero;
    }

    private void Shoot()
    {
        var clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (clickPosition - this.gameObject.transform.position).normalized;

        var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity, this.transform);
        var bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.Direction = direction;
        
        Debug.Log($"Clicked at {direction}");
    }

    public void Kill()
    {
        IsAlive = false;
        Debug.Log("Player died.");

        GameState.Instance.GameLost = true;
    }
}
