using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    // config props
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip bossBattleMusic;

    // cache
    AudioSource _musicAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        _musicAudioSource = GetComponent<AudioSource>();

        PlayRegularGameMusic();
    }

    public void PlayRegularGameMusic()
    {
        _musicAudioSource.Stop();
        _musicAudioSource.clip = gameMusic;
        _musicAudioSource.Play();
    }

    public void PlayBossBattleMusic()
    {
        _musicAudioSource.Stop();
        _musicAudioSource.clip = bossBattleMusic;
        _musicAudioSource.Play();
    }

}
