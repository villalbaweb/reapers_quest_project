using UnityEngine;

public class LevelExitEnabler : MonoBehaviour
{
    //cache
    EnemyHealth _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        BossController bossGameObject = FindObjectOfType<BossController>();
        _enemyHealth = bossGameObject?.GetComponent<EnemyHealth>();

        SubscribeHealthEvents();
    }

    private void OnDieEvent()
    {
        gameObject.SetActive(true);
        UnsubscribeHealthEvents();
    }

    private void SubscribeHealthEvents()
    {
        if (!_enemyHealth) return;

        _enemyHealth.OnDie += OnDieEvent;
    }

    private void UnsubscribeHealthEvents()
    {
        if (!_enemyHealth) return;

        _enemyHealth.OnDie -= OnDieEvent;
    }
}
