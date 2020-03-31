﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class BossDieHandler : MonoBehaviour
{
    // config params
    [SerializeField] float timeToDestroyAfterDeath = 0.5f;
    
    // cache
    EnemyHealth _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();

        SubscribeHealthEvents();
    }

    private void OnDestroy() 
    {
        UnsubscribeHealthEvents();    
    }

    private void OnDieEvent()
    {
        HandleDeath();
    }

    private void HandleDeath()
    {
        StartCoroutine(DieVFX());
    }

    IEnumerator DieVFX()
    {
        yield return new WaitForSeconds(timeToDestroyAfterDeath);
        Destroy(gameObject);
    }

    private void SubscribeHealthEvents()
    {
        _enemyHealth.OnDie += OnDieEvent;
    }

    private void UnsubscribeHealthEvents()
    {
        _enemyHealth.OnDie -= OnDieEvent;
    }

}