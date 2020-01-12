using System.Collections;
using UnityEngine;

public class Boss1SpecialAttack : MonoBehaviour {

    // config params
    [SerializeField] float specialAttackEnabledTime = 0.5f;
    [SerializeField] GameObject explosionParticleEffect = null;
    [SerializeField] Transform explosionParticleSystemPosition = null;

    // cache
    BoxCollider2D _specialAttackBoxCollider2D;
    
    private void Start() {
        _specialAttackBoxCollider2D = GetComponent<BoxCollider2D>();
        _specialAttackBoxCollider2D.enabled = false;
    }

    private void AttackAnimationEvent()
    {
        if (_specialAttackBoxCollider2D == null) return;
        
        StartCoroutine(EnableSpecialAttackCollider());
    }

    IEnumerator EnableSpecialAttackCollider()
    {
        GameObject explosionParticles = Instantiate(explosionParticleEffect, explosionParticleSystemPosition.position, Quaternion.identity);
        _specialAttackBoxCollider2D.enabled = true;
        yield return new WaitForSecondsRealtime(specialAttackEnabledTime);
        Destroy(explosionParticles);
        _specialAttackBoxCollider2D.enabled = false;
    }
}