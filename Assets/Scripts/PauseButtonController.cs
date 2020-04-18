using UnityEngine;

public class PauseButtonController : MonoBehaviour
{
    private bool isPaused = false;

    public void PauseControl()
    {
        isPaused = !isPaused;

        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }
}
