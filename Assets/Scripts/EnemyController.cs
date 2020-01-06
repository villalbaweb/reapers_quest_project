using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Config params
    [Header("Audio Effects")]
    [SerializeField] AudioClip dieAudioSFX = null;
    [SerializeField] float audioSFXVolume = 0.3f;

    // Cache
    Animator _animator;
    EnemyHealth _enemyHealth;
    EnemyDieHandler _enemyDieHandler;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyDieHandler = GetComponent<EnemyDieHandler>();

        _enemyHealth.OnDie += OnDieEvent;
    }

    private void OnDestroy() {
        _enemyHealth.OnDie -= OnDieEvent;
    }

    private void OnDieEvent()
    {
        _animator.SetTrigger("Die");
        PlayDieSFX();
        
        _enemyDieHandler.HandleDeath();
    }

    private void PlayDieSFX()
    {
        if (!dieAudioSFX) { return; }

        AudioSource.PlayClipAtPoint(dieAudioSFX, Camera.main.transform.position, audioSFXVolume);
    }


}
