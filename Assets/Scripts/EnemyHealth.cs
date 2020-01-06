using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Events
    public delegate void HitEvent();
    public event HitEvent OnHit;

    public delegate void DieEvent();
    public event DieEvent OnDie;

    // Config params
    [Header("Health")]
    [SerializeField] int health = 300;

    // Cache
    bool isDead;

    private void Start()
    {
        isDead = false;
    }

    private void CheckLife()
    {
        if(!isDead && health <= 0)
        {
            isDead = true;
            // emit OnDie event
            if(OnDie != null) OnDie();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckLife();

        // emit OnHit event
        if (!isDead && OnHit != null) OnHit();
    }
}
