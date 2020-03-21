using UnityEngine;

public class Boss2Movement : MonoBehaviour
{
    const float BOSS2_ANIMATOR_MAX_SPEED = 3.0f;

    // Cache
    Rigidbody2D _rigidbody2D;
    EnemyHealth _enemyHealth;
    Player _player;

    //status
    int initialHealth;
    float calculatedMoveSpeed;
    bool isOnEdge = false;

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
        if(isOnEdge)
        {
            calculatedMoveSpeed = 0;
            return;
        }

        float speedPercentage = 1 - ((float)_enemyHealth.RemainingHealth / (float)initialHealth);
        float speed = BOSS2_ANIMATOR_MAX_SPEED * speedPercentage;

        calculatedMoveSpeed = speed > 0.5 ? speed : 0;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player Projectile") return;
        isOnEdge = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player Projectile") return;
        isOnEdge = false;    
    }
}
