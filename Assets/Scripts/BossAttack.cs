using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth), typeof(Animator))]
public class BossAttack : MonoBehaviour {
    
    // config paranms
    [SerializeField] float baseTimeBetweenAttacks = 10f;

    // cache
    Animator _animator;
    EnemyHealth _enemyHealth;

    // state
    float timeSincelastAttack = 0f;
    float timeBetweenAttacks;

    private void Start() {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();

        timeBetweenAttacks = baseTimeBetweenAttacks;
    }

    private void Update() {

        if(_enemyHealth.IsDead) { return; }

        Attack();
    }

    private void Attack() {
        timeSincelastAttack += Time.deltaTime;
        if(timeSincelastAttack >= timeBetweenAttacks) {
            timeSincelastAttack = 0;
            _animator.SetTrigger("Attack");
        }
    }

    public void CalculateTimeBetweenAttacksBasedOnHealth(int initialHealth, int remainingHealth) {
        float percentageLeft = (float)remainingHealth / (float)initialHealth;

        if (percentageLeft < .8f && percentageLeft > .5f) {
            timeBetweenAttacks = baseTimeBetweenAttacks * percentageLeft;
        }
    }
}