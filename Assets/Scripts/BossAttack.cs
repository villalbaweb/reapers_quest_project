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
    int initialBossHealth;

    private void Start() {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();

        timeBetweenAttacks = baseTimeBetweenAttacks;
        initialBossHealth = _enemyHealth.RemainingHealth;

        _enemyHealth.OnHit += OnHitEvent;
    }
    
    private void OnDestroy() {
        _enemyHealth.OnHit -= OnHitEvent;
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

    private void CalculateTimeBetweenAttacksBasedOnHealth(int initialHealth, int remainingHealth) {
        float percentageLeft = (float)remainingHealth / (float)initialHealth;

        if (percentageLeft < .8f && percentageLeft > .5f) {
            timeBetweenAttacks = baseTimeBetweenAttacks * percentageLeft;
        }
    }

    private void OnHitEvent()
    {
        CalculateTimeBetweenAttacksBasedOnHealth(initialBossHealth, _enemyHealth.RemainingHealth);
    }
}