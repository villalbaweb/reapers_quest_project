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
    public int RemainingHealth { 
        get {
            return health;
        }
    }

    public bool IsDead { get; set; }

    private void Start()
    {
        IsDead = false;
    }

    public void TakeDamage(int damage)
    {
        if(IsDead) { return; }

        health -= damage;

        if (health <= 0)
        {
            IsDead = true;
            // emit OnDie event
            if (OnDie != null) OnDie();
        } 
        else
        {
            if (OnHit != null) OnHit();
        }
    }
}
