﻿using UnityEngine;
using UnityEngine.UI;

public class GameMusicSwitchButtonController : MonoBehaviour
{
    // config params
    [Header("Image")]
    [SerializeField] Sprite musicOnSprite = null;
    [SerializeField] Sprite musicOffSprite = null;

    // cache
    Image _image;
    GameMusic _gameMusic;

    // status
    bool isGameMusicMuted = false;

    void Start() 
    {
        _image = GetComponent<Image>();
        _gameMusic = FindObjectOfType<GameMusic>(); 

        isGameMusicMuted = _gameMusic.isMuted;

        UpdateButtonImage();  
    }

    public void SwitchGameMusicMute()
    {
        isGameMusicMuted = !isGameMusicMuted;

        _gameMusic.SwitchMusicMute(isGameMusicMuted);

        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        _image.sprite = isGameMusicMuted ? musicOffSprite : musicOnSprite;
    }
}
