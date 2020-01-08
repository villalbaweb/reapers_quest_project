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

    // State
    bool isDead;

    private void Start()
    {
        isDead = false;
    }

    public void TakeDamage(int damage)
    {
        if(isDead) { return; }

        health -= damage;

        if (health <= 0)
        {
            isDead = true;
            // emit OnDie event
            if (OnDie != null) OnDie();
        } 
        else
        {
            if (OnHit != null) OnHit();
        }
    }
}
