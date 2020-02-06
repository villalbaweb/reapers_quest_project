using UnityEngine;

[RequireComponent(typeof(EnemyHealth), typeof(Swing))]
public class SwingerObstacleController : MonoBehaviour
{
    // cache
    EnemyHealth _enemyHealth;
    Swing _swing;

    // Start is called before the first frame update
    void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _swing = GetComponent<Swing>();
        
        _enemyHealth.OnDie += OnDestroySwinger;
        
        _swing.StartSwing();
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
