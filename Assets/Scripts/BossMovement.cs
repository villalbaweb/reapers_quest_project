using UnityEngine;

public class BossMovement : MonoBehaviour 
{
    // config params
    [SerializeField] float moveSpeed = 1f;

    // Cache
    Rigidbody2D _rigidbody2D;

    // state
    [SerializeField] bool movingRight;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        movingRight = false;
    }

    void Update() {
        Vector2 bossVelocity = new Vector2(movingRight ? moveSpeed : moveSpeed * -1, _rigidbody2D.velocity.y);

        _rigidbody2D.velocity = bossVelocity;
    }
}