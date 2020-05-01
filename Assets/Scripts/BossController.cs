using UnityEngine;

public class BossController : MonoBehaviour
{
    // Config params
    [Header("Audio Effects")]
    [SerializeField] AudioClip dieAudioSFX = null;
    [SerializeField] AudioClip hurtAudioSFX = null;

    // cache
    Animator _animator;
    EnemyHealth _enemyHealth;
    Rigidbody2D _rigidbody2D;
    GameSound _gameSound;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameSound = FindObjectOfType<GameSound>();

        SubscribeHealthEvents();
    }

    private void OnDestroy() 
    {
        UnsubscribeHealthEvents();
    }

    void Update() 
    {
        if (_enemyHealth.IsDead) return;

        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody2D.velocity.x));    
    }

    private void OnHitEvent()
    {
        if (_enemyHealth.IsDead) return;
        
        _animator.SetTrigger("TakeDamage");
        PlayHurtSFX();
    }

    private void OnDieEvent()
    {
        _animator.SetTrigger("Die");
        PlayDieSFX();

        UnsubscribeHealthEvents();
    }

    private void PlayHurtSFX()
    {
        _gameSound.PlayClipAtCamera(hurtAudioSFX);
    }

    private void PlayDieSFX()
    {
        _gameSound.PlayClipAtCamera(dieAudioSFX);
    }

    private void SubscribeHealthEvents()
    {
        _enemyHealth.OnHit += OnHitEvent;
        _enemyHealth.OnDie += OnDieEvent;
    }

    private void UnsubscribeHealthEvents()
    {
        _enemyHealth.OnHit -= OnHitEvent;
        _enemyHealth.OnDie -= OnDieEvent;
    }

}
