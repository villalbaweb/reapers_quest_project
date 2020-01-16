using System.Collections;
using UnityEngine;

public class Boss1SpecialAttack : MonoBehaviour {

    // config params
    [SerializeField] float specialAttackEnabledTime = 0.5f;
    [SerializeField] GameObject explosionParticleEffect = null;
    [SerializeField] Transform explosionParticleSystemPosition = null;

    private void AttackAnimationEvent()
    {
        StartCoroutine(EnableSpecialAttackCollider());
    }

    IEnumerator EnableSpecialAttackCollider()
    {
        GameObject explosionParticles = Instantiate(explosionParticleEffect, explosionParticleSystemPosition.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(specialAttackEnabledTime);
        Destroy(explosionParticles);
    }
}