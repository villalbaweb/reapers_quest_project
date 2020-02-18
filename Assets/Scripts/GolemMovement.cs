using UnityEngine;

public class GolemMovement : MonoBehaviour
{
    // Config Params
    [SerializeField] float patrolSpeed = 1.5f;
    [SerializeField] float attackSpeed = 4f;
    [SerializeField] float chaseDistance = 1f;

    // Cache
    Rigidbody2D _rigidbody2D;
    Player _player;
    Animator _animator;

    // state
    bool isAttacking;
    bool isAttackingOnEdge;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = IsInAttackRange();

        if(isAttacking)
        {
            Attack();
        }
        else
        {
            Patrol();
        }
    }

    private bool IsInAttackRange()
    {
        return Vector2.Distance(_player.transform.position, transform.position) <= chaseDistance;
    }

    private void Attack()
    {
        _animator.SetBool("InAttackRange", true);

        if(!isAttackingOnEdge) 
        {
            CalculateDirection();
            Move(attackSpeed);
        }
    }

    public void Patrol()
    {
        _animator.SetBool("InAttackRange", false);

        if (isAttackingOnEdge)
        {
            ChangeDirection();
            isAttackingOnEdge = false;
        }

        Move(patrolSpeed);
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

    private void Move(float moveSpeed)
    {
        Vector2 playerVelocity;
        if (IsFacingRight())
        {
            playerVelocity = new Vector2(moveSpeed, _rigidbody2D.velocity.y);
        }
        else
        {
            playerVelocity = new Vector2(-moveSpeed, _rigidbody2D.velocity.y);
        }

        _rigidbody2D.velocity = playerVelocity;
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!isAttacking)
        {
            ChangeDirection();
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            isAttackingOnEdge = true;
        }
    }

    // called by Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}
