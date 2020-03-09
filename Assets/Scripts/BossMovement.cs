using UnityEngine;

[RequireComponent(typeof(Timer))]
public class BossMovement : MonoBehaviour 
{
    // config params
    [SerializeField] float moveSpeed = 1f;

    // Cache
    Rigidbody2D _rigidbody2D;
    Timer _timer;
    EnemyHealth _enemyHealth;

    // state
    [SerializeField] bool isMovingRight;
    [SerializeField] bool isMoving;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _timer = GetComponent<Timer>();
        _enemyHealth = GetComponent<EnemyHealth>();

        InitializeDirectionControl();

        SubscribeEvents();
    }

    void OnDestroy() 
    {
        UnsubscribeEvents();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 bossVelocity = isMoving 
            ? new Vector2(isMovingRight ? moveSpeed : moveSpeed * -1, _rigidbody2D.velocity.y)
            : new Vector2();

        _rigidbody2D.velocity = bossVelocity;
    }

    void InitializeDirectionControl()
    {
        isMovingRight = true;
        isMoving = false;
    }

    void SubscribeEvents()
    {
        _timer.OnTick += TimerTickAction;

        _enemyHealth.OnDie += OnDieEvent;
    }

    void UnsubscribeEvents()
    {
        _timer.OnTick -= TimerTickAction;

        _enemyHealth.OnDie -= OnDieEvent;
    }

    void TimerTickAction()
    {
        isMoving = !isMoving;
        isMovingRight = isMoving ? !isMovingRight : isMovingRight;
    }

    private void OnDieEvent()
    {
        StopMoving();
    }

    private void StopMoving() 
    {
        _timer.StopTimer();
        isMoving = false;
    }
}