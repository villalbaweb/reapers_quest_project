using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    // config params
    [Header("Image")]
    [SerializeField] Sprite pauseSprite = null;
    [SerializeField] Sprite continueSprite = null;

    [Header("Panel")]
    [SerializeField] GameMenuPanelController _panel = null;

    // state
    private bool isPaused = false;

    // cache
    Image _image;
    GameSession _gameSession;

    private void Start() 
    {
        _image = GetComponent<Image>();   
        _gameSession = FindObjectOfType<GameSession>(); 
    }

    public void PauseControl()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            _image.sprite = continueSprite;
            _gameSession.SetTimeScaleStop();
            EnableMenu();
        }
        else
        {
            _image.sprite = pauseSprite;
            _gameSession.SetTimeScaleNormal();
            DisableMenu();
        }

    }

    private void EnableMenu()
    {
        if(_panel)
        {
            _panel.Enable();
        }
    }

    private void DisableMenu()
    {
        if (_panel)
        {
            _panel.Disable();
        }
    }
}
