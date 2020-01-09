using UnityEngine;

public class BossMovement : MonoBehaviour 
{
    // config params
    [SerializeField] float moveSpeed = 1f;

    // Cache
    Rigidbody2D _rigidbody2D;
    Timer _timer;

    // state
    [SerializeField] bool isMovingRight;
    [SerializeField] bool isMoving;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _timer = GetComponent<Timer>();

        InitializeDirectionControl();

        SubscribeTimerEvents();
    }



    void OnDestroy() 
    {
        UnsubscribeTimerEvents();
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

    void SubscribeTimerEvents()
    {
        _timer.OnTick += TimerTickAction;
    }

    void UnsubscribeTimerEvents()
    {
        _timer.OnTick -= TimerTickAction;
    }

    void TimerTickAction()
    {
        isMoving = !isMoving;
        isMovingRight = isMoving ? !isMovingRight : isMovingRight;
    }
}