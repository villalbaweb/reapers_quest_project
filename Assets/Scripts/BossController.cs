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
    Rigidbody2D _rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

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
        if (!hurtAudioSFX) { return; }

        AudioSource.PlayClipAtPoint(hurtAudioSFX, Camera.main.transform.position, audioSFXVolume);
    }

    private void PlayDieSFX()
    {
        if (!dieAudioSFX) { return; }

        AudioSource.PlayClipAtPoint(dieAudioSFX, Camera.main.transform.position, audioSFXVolume);
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
