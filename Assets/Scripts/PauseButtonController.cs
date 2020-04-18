using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    // config params
    [SerializeField] Sprite pauseSprite = null;
    [SerializeField] Sprite continueSprite = null;

    // state
    private bool isPaused = false;

    // cache
    Image _image;

    private void Start() 
    {
        _image = GetComponent<Image>();    
    }

    public void PauseControl()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            _image.sprite = continueSprite;
            Time.timeScale = 0;
        }
        else
        {
            _image.sprite = pauseSprite;
            Time.timeScale = 1;
        }

    }
}
