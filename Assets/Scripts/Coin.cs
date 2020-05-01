﻿using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    const string PICKUPS_PARENT_NAME = "Pickups";

    // Config Params
    [Header("Configurations")]
    [SerializeField] float timeToDestroyCoinAfterTaken = 0.5f;
    [SerializeField] AudioClip _takenSFX = null;

    // Cache
    GameObject _pickupParent;
    Animator _animator;
    GameSession _gameSession;
    GameSound _gameSound;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _gameSession = FindObjectOfType<GameSession>();
        _gameSound = FindObjectOfType<GameSound>();

        CreateCoinParent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player _player = collision.GetComponent<Player>();

        if(!_player) return;

        StartCoroutine(TakeCoin());
    }

    IEnumerator TakeCoin()
    {
        PlayTakenSFX();
        _animator.SetTrigger("TakeCoin");
        yield return new WaitForSecondsRealtime(timeToDestroyCoinAfterTaken);
        Destroy(gameObject);
        _gameSession.CollectCoin(1);
    }

    private void PlayTakenSFX()
    {
        _gameSound.PlayClipAtCamera(_takenSFX, 0.25f);
    }

    private void CreateCoinParent()
    {
        _pickupParent = GameObject.Find(PICKUPS_PARENT_NAME);

        if (!_pickupParent)
        {
            _pickupParent = new GameObject(PICKUPS_PARENT_NAME);
        }

        transform.parent = _pickupParent.transform;
    }
}
