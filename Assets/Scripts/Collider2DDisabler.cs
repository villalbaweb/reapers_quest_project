using UnityEngine;

public class Collider2DDisabler : MonoBehaviour
{
    //cache
    EnemyHealth _enemyHealth;
    CapsuleCollider2D _capsuleCollider2D;
    BoxCollider2D _boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        BossController bossGameObject = FindObjectOfType<BossController>();

        _enemyHealth = bossGameObject.GetComponent<EnemyHealth>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        SubscribeHealthEvents();
    }

    private void OnDestroy() 
    {
        UnsubscribeHealthEvents();    
    }

    private void OnDieEvent()
    {
        if (_capsuleCollider2D)
            _capsuleCollider2D.enabled = false;

        if (_boxCollider2D)
            _boxCollider2D.enabled = false;
    }

    private void SubscribeHealthEvents()
    {
        _enemyHealth.OnDie += OnDieEvent;
    }

    private void UnsubscribeHealthEvents()
    {
        _enemyHealth.OnDie -= OnDieEvent;
    }

}
