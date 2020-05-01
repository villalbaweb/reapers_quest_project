using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Config params
    [Header("Audio Effects")]
    [SerializeField] AudioClip dieAudioSFX = null;

    // Cache
    Animator _animator;
    EnemyHealth _enemyHealth;
    GameSound _gameSound;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _gameSound = FindObjectOfType<GameSound>();

        _enemyHealth.OnDie += OnDieEvent;
    }

    private void OnDestroy() {
        _enemyHealth.OnDie -= OnDieEvent;
    }

    private void OnDieEvent()
    {
        _animator.SetTrigger("Die");
        PlayDieSFX();
    }

    private void PlayDieSFX()
    {
        _gameSound.PlayClipAtCamera(dieAudioSFX);
    }


}
