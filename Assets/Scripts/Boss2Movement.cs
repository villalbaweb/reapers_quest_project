using UnityEngine;

public class Boss2Movement : MonoBehaviour
{
    // Cache
    Rigidbody2D _rigidbody2D;
    EnemyHealth _enemyHealth;
    Player _player;

    //status
    int initialHealth;
    float calculatedMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _player = FindObjectOfType<Player>();

        initialHealth = _enemyHealth.RemainingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDirection();
        CalculateMovementSpeed();
        Move();
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

    private void CalculateMovementSpeed()
    {
        if(_enemyHealth.RemainingHealth >= 2000)
        {
            calculatedMoveSpeed = 0;
        }
        else if (_enemyHealth.RemainingHealth >= 1500)
        {
            calculatedMoveSpeed = 1;
        }
        else if (_enemyHealth.RemainingHealth >= 1000)
        {
            calculatedMoveSpeed = 2;
        }
        else
        {
            calculatedMoveSpeed = 3;
        }
    }

    private void Move()
    {
        Vector2 bossMovement;
        if (IsFacingRight())
        {
            bossMovement = new Vector2(calculatedMoveSpeed, _rigidbody2D.velocity.y);
        }
        else
        {
            bossMovement = new Vector2(-calculatedMoveSpeed, _rigidbody2D.velocity.y);
        }

        _rigidbody2D.velocity = bossMovement;
    }
}
