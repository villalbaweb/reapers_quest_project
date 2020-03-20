using UnityEngine;

public class Boss2Movement : MonoBehaviour
{
    // config params
    [SerializeField] float moveSpeed = 2f;

    // Cache
    Rigidbody2D _rigidbody2D;
    Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDirection();
        Move();
    }

    private void Move()
    {
        Vector2 bossMovement;
        if (IsFacingRight())
        {
            bossMovement = new Vector2(moveSpeed, _rigidbody2D.velocity.y);
        }
        else
        {
            bossMovement = new Vector2(-moveSpeed, _rigidbody2D.velocity.y);
        }

        _rigidbody2D.velocity = bossMovement;
    }

    private void CalculateDirection()
    {
        float distanceDiff = _player.transform.position.x - transform.position.x;
        if ((distanceDiff > 0 && !IsFacingRight()) || distanceDiff < 0 && IsFacingRight()) ChangeDirection();
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector2(IsFacingRight() ? -1 : 1, 1f);
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
}
