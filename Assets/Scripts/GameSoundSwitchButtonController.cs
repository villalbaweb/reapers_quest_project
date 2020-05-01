using UnityEngine;
using UnityEngine.UI;

public class GameSoundSwitchButtonController : MonoBehaviour
{
    // config params
    [Header("Image")]
    [SerializeField] Sprite musicOnSprite = null;
    [SerializeField] Sprite musicOffSprite = null;

    // cache
    Image _image;
    GameSound _gameSound;

    // status
    bool isGameSoundMuted;

    void Start()
    {
        _image = GetComponent<Image>();
        _gameSound = FindObjectOfType<GameSound>();

        isGameSoundMuted = _gameSound.IsSoundMute;
        
        UpdateButtonImage();
    }

    public void SwitchGameSoundMute()
    {
        isGameSoundMuted = !isGameSoundMuted;

        _gameSound.SwitchSoundMute(isGameSoundMuted);

        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        _image.sprite = isGameSoundMuted ? musicOffSprite : musicOnSprite;
    }
}
