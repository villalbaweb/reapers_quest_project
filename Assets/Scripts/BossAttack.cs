using UnityEngine;

public class BossAttack : MonoBehaviour {
    
    // config paranms
    [SerializeField] float timeBetweenAttacks = 2f;

    // cache
    Animator _animator;

    // state
    float timeSincelastAttack = 0f;

    private void Start() {
        _animator = GetComponent<Animator>();
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
}