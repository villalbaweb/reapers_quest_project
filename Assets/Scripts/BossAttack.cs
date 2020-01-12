using UnityEngine;

public class BossAttack : MonoBehaviour {
    
    // config paranms
    [SerializeField] float baseTimeBetweenAttacks = 10f;

    // cache
    Animator _animator;

    // state
    float timeSincelastAttack = 0f;
    float timeBetweenAttacks;

    private void Start() {
        _animator = GetComponent<Animator>();

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

    public void CalculateTimeBetweenAttacksBasedOnHealth(int initialHealth, int remainingHealth) {
        float percentageLeft = (float)remainingHealth / (float)initialHealth;

        if (percentageLeft < .8f && percentageLeft > .5f) {
            timeBetweenAttacks = baseTimeBetweenAttacks * percentageLeft;
        }
    }
}