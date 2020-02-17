using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMovement : MonoBehaviour
{
    // Config Params
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float attackSpeed = 2f;
    [SerializeField] float chaseDistance = 1f;

    // Cache
    Rigidbody2D _rigidbody2D;
    Player _player;
    Animator _animator;

    // state
    bool isAttackRange;
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
        isAttackRange = IsInAttackRange();

        if(isAttackRange)
        {
            Attack();
        }
        else
        {
            Patrol();
        }
    }

    private void Attack()
    {
        _animator.SetBool("InAttackRange", true);
    }

    public void Patrol()
    {
        if(isAttackingOnEdge)
        {
            ChangeDirection();
            isAttackingOnEdge = false;
        }
        _animator.SetBool("InAttackRange", false);
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
        if(!isAttackRange)
        {
            ChangeDirection();
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            isAttackingOnEdge = true;
        }
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector2(IsFacingRight() ? -1 : 1, 1f);
    }

    private bool IsInAttackRange()
    {
        return Vector2.Distance(_player.transform.position, transform.position) <= chaseDistance;
    }

    // called by Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}
