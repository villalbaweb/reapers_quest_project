using UnityEngine;

public class BossController : MonoBehaviour
{
    // Config params
    [Header("Audio Effects")]
    [SerializeField] AudioClip dieAudioSFX = null;
    [SerializeField] AudioClip hurtAudioSFX = null;
    [SerializeField] float audioSFXVolume = 0.3f;

    // cache
    Animator _animator;
    EnemyHealth _enemyHealth;
    EnemyDieHandler _enemyDieHandler;
    BossMovement _bossMovement;
    BossAttack _bossAttack;
    Rigidbody2D _rigidbody2D;

    // state
    int initialBossHealth;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyDieHandler = GetComponent<EnemyDieHandler>();
        _bossMovement = GetComponent<BossMovement>();
        _bossAttack = GetComponent<BossAttack>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _enemyHealth.OnHit += OnHitEvent;
        _enemyHealth.OnDie += OnDieEvent;

        initialBossHealth = _enemyHealth.RemainingHealth;
    }

    private void OnDestroy() {
        _enemyHealth.OnHit -= OnHitEvent;
        _enemyHealth.OnDie -= OnDieEvent;
    }

    void Update() 
    {
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody2D.velocity.x));    
    }

    private void OnHitEvent()
    {
        _bossAttack.CalculateTimeBetweenAttacksBasedOnHealth(initialBossHealth, _enemyHealth.RemainingHealth);

        _animator.SetTrigger("TakeDamage");
        PlayHurtSFX();
    }

    private void OnDieEvent()
    {
        _animator.SetTrigger("Die");
        PlayDieSFX();

        _enemyDieHandler.HandleDeath();
        _bossMovement.StopMoving();
    }

    private void PlayHurtSFX()
    {
        if (!hurtAudioSFX) { return; }

        AudioSource.PlayClipAtPoint(hurtAudioSFX, Camera.main.transform.position, audioSFXVolume);
    }

    private void PlayDieSFX()
    {
        if (!dieAudioSFX) { return; }

        AudioSource.PlayClipAtPoint(dieAudioSFX, Camera.main.transform.position, audioSFXVolume);
    }

}
