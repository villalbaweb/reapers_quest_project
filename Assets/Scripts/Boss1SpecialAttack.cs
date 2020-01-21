using System.Collections;
using UnityEngine;

public class Boss1SpecialAttack : MonoBehaviour {

    // config params
    [SerializeField] float specialAttackEnabledTime = 0.5f;
    [SerializeField] GameObject explosionParticleEffect = null;
    [SerializeField] Transform explosionParticleSystemPosition = null;
    [SerializeField] AudioClip attackSFX = null;
    [SerializeField] float audioSFXVolume = 0.3f;

    private void AttackSFXPlayAnimationEvent()
    {
        if (!attackSFX) { return; }

        AudioSource.PlayClipAtPoint(attackSFX, Camera.main.transform.position, audioSFXVolume);
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