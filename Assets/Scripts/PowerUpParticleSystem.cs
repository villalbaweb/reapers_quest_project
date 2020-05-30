using UnityEngine;

public class PowerUpParticleSystem : MonoBehaviour
{
    //config params
    [SerializeField] int powerUpDamage = 1000;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth)
        {
            enemyHealth.TakeDamage(powerUpDamage);
        }
    }
}
