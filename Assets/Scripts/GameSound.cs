using UnityEngine;

public class GameSound : MonoBehaviour
{
    // state
    public bool IsSoundMute 
    { 
        get{ return _isSoundMute; }
    }

    private bool _isSoundMute = false;

    public void SwitchSoundMute(bool isMuted)
    {
        print($"Set sound {isMuted}");
        _isSoundMute = isMuted;
    }
}
