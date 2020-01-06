using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyDieHandler = GetComponent<EnemyDieHandler>();

        _enemyHealth.OnHit += OnHitEvent;
        _enemyHealth.OnDie += OnDieEvent;
    }

    private void OnDestroy() {
        _enemyHealth.OnHit -= OnHitEvent;
        _enemyHealth.OnDie -= OnDieEvent;
    }

    private void OnHitEvent()
    {
        _animator.SetTrigger("TakeDamage");
        PlayHurtSFX();
    }

    private void OnDieEvent()
    {
        _animator.SetTrigger("Die");
        PlayDieSFX();

        _enemyDieHandler.HandleDeath();
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
