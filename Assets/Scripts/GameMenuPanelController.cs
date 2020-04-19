using UnityEngine;

public class GameMenuPanelController : MonoBehaviour
{
    // cache
    GameObject[] _gameControls;

    // Start is called before the first frame update
    void Start()
    {
        _gameControls = GameObject.FindGameObjectsWithTag("GameController");

        Disable();
    }

    public void Enable() 
    {
        EnableDisableGameControls(false);
        gameObject.SetActive(true);    
    }

    public void Disable()
    {
        EnableDisableGameControls(true);
        gameObject.SetActive(false);
    }

    private void EnableDisableGameControls(bool isEnable)
    {
        foreach(GameObject control in _gameControls)
        {
            // print($"{control.name}");
            control.SetActive(isEnable);
        }
    }
}
