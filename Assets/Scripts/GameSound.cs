using UnityEngine;

public class GameSound : MonoBehaviour
{
    // config params
    [SerializeField] float audioVolume = 1f;

    // state
    public bool IsSoundMute
    {
        get { return _isSoundMute; }
    }
    private bool _isSoundMute = false;

    public void SwitchSoundMute(bool isMuted)
    {
        print($"Set sound {isMuted}");
        _isSoundMute = isMuted;
    }

    public void PlayClipAtCamera(AudioClip clip, float specificVolume = -1)
    {
        if(!clip || _isSoundMute) return;

        float playSoundVolume = specificVolume == -1 ? audioVolume : specificVolume;

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, playSoundVolume);
    }
}
