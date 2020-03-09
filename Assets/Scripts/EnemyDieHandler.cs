using System.Collections;
using UnityEngine;

public class EnemyDieHandler : MonoBehaviour
{
    // config params
    [SerializeField] float timeToDestroyAfterDeath = 0.5f;

    // cache
    CapsuleCollider2D _mainBodyCollider2D;
    BoxCollider2D _feetCollider2D;
    EnemyHealth _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        _mainBodyCollider2D = GetComponent<CapsuleCollider2D>();
        _feetCollider2D = GetComponent<BoxCollider2D>();
        _enemyHealth = GetComponent<EnemyHealth>();

        _enemyHealth.OnDie += OnDieEvent;
    }

    private void OnDestroy() {
        _enemyHealth.OnDie -= OnDieEvent;
    }

    private void OnDieEvent()
    {
        HandleDeath();
    }

    private void HandleDeath() 
    {
        StartCoroutine(DieVFX());
    }

    IEnumerator DieVFX()
    {
        if (_mainBodyCollider2D)
        {
            _mainBodyCollider2D.enabled = false;
        }

        if (_feetCollider2D)
        {
            _feetCollider2D.enabled = false;
        }

        yield return new WaitForSeconds(timeToDestroyAfterDeath);
        Destroy(gameObject);
    }

}
