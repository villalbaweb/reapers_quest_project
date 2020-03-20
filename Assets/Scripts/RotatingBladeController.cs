using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class RotatingBladeController : MonoBehaviour
{
    // cache
    EnemyHealth _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();

        _enemyHealth.OnDie += OnDestroySwinger;
    }

    private void OnDestroy()
    {
        _enemyHealth.OnDie -= OnDestroySwinger;
    }

    private void OnDestroySwinger()
    {
        Destroy(gameObject);
    }
}
