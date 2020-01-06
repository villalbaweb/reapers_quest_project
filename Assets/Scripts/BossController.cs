using UnityEngine;

public class BossController : MonoBehaviour
{
    // cache
    Animator _animator;
    EnemyHealth _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyHealth.OnHit += OnHitEvent;
    }

    private void OnDestroy() {
        _enemyHealth.OnHit -= OnHitEvent;
    }

    private void OnHitEvent() {
        _animator.SetTrigger("TakeDamage");
    }

}
