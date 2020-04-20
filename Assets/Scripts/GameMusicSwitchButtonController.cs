using UnityEngine;
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
    }

    public void SwitchGameMusicMute()
    {
        isGameMusicMuted = !isGameMusicMuted;

        _gameMusic.SwitchMusicMute(isGameMusicMuted);

        _image.sprite = isGameMusicMuted ? musicOffSprite : musicOnSprite;
    }

}
