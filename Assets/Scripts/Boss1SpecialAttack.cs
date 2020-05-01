using System.Collections;
using UnityEngine;

public class Boss1SpecialAttack : MonoBehaviour {

    // config params
    [SerializeField] float specialAttackEnabledTime = 0.5f;
    [SerializeField] GameObject explosionParticleEffect = null;
    [SerializeField] Transform explosionParticleSystemPosition = null;
    [SerializeField] AudioClip attackSFX = null;

    // Cache
    GameSound _gameSound;

    void Start() 
    {
        _gameSound = FindObjectOfType<GameSound>();
    }

    private void AttackSFXPlayAnimationEvent()
    {
        _gameSound.PlayClipAtCamera(attackSFX);
    }

    private void AttackAnimationEvent()
    {
        StartCoroutine(SpecialAttack());
    }

    IEnumerator SpecialAttack()
    {
        GameObject explosionParticles = Instantiate(explosionParticleEffect, explosionParticleSystemPosition.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(specialAttackEnabledTime);
        Destroy(explosionParticles);
    }
}