using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour {
    
    // config paranms
    [SerializeField] float baseTimeBetweenAttacks = 10f;
    [SerializeField] float specialAttackEnabledTime = 0.5f;

    // cache
    Animator _animator;
    BoxCollider2D _specialAttackBoxCollider2D;

    // state
    float timeSincelastAttack = 0f;
    float timeBetweenAttacks;

    private void Start() {
        _animator = GetComponent<Animator>();
        _specialAttackBoxCollider2D = GetComponent<BoxCollider2D>();

        _specialAttackBoxCollider2D.enabled = false;

        timeBetweenAttacks = baseTimeBetweenAttacks;
    }

    private void Update() {
        Attack();
    }

    private void Attack() {
        timeSincelastAttack += Time.deltaTime;
        if(timeSincelastAttack >= timeBetweenAttacks) {
            timeSincelastAttack = 0;
            _animator.SetTrigger("Attack");
        }
    }

    private void AttackAnimationEvent() {
        if (_specialAttackBoxCollider2D == null) return;

        StartCoroutine(EnableSpecialAttackCollider());
    }

    IEnumerator EnableSpecialAttackCollider() {
        _specialAttackBoxCollider2D.enabled = true;
        yield return new WaitForSecondsRealtime(specialAttackEnabledTime);
        _specialAttackBoxCollider2D.enabled = false;
    } 

    public void CalculateTimeBetweenAttacksBasedOnHealth(int initialHealth, int remainingHealth) {
        float percentageLeft = (float)remainingHealth / (float)initialHealth;

        if (percentageLeft < .8f && percentageLeft > .5f) {
            timeBetweenAttacks = baseTimeBetweenAttacks * percentageLeft;
        }
    }
}