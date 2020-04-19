using UnityEngine;

public class GameMenuPanelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Disable();
    }

    public void Enable() 
    {
        gameObject.SetActive(true);    
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
