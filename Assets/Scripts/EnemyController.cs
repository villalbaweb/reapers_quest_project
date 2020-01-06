using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Config params
    [Header("Health")]
    [SerializeField] float timeToDestroyAfterDeath = 0.5f;

    [Header("Audio Effects")]
    [SerializeField] AudioClip dieAudioSFX = null;
    [SerializeField] float audioSFXVolume = 0.3f;

    // Cache
    Animator _animator;
    CapsuleCollider2D _mainBodyCollider2D;
    BoxCollider2D _feetCollider2D;
    EnemyHealth _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _mainBodyCollider2D = GetComponent<CapsuleCollider2D>();
        _feetCollider2D = GetComponent<BoxCollider2D>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyHealth.OnDie += OnDieEvent;
    }

    private void OnDestroy() {
        _enemyHealth.OnDie -= OnDieEvent;
    }

    private void OnDieEvent()
    {
        StartCoroutine(DieVFX());
    }

    IEnumerator DieVFX()
    {
        if (_mainBodyCollider2D)
        {
            _mainBodyCollider2D.enabled = false;
        }

        if (_feetCollider2D)
        {
            _feetCollider2D.enabled = false;
        }
        _animator.SetTrigger("Die");
        PlayDieSFX();
        yield return new WaitForSeconds(timeToDestroyAfterDeath);
        Destroy(gameObject);
    }

    private void PlayDieSFX()
    {
        if (!dieAudioSFX) { return; }

        AudioSource.PlayClipAtPoint(dieAudioSFX, Camera.main.transform.position, audioSFXVolume);
    }


}
