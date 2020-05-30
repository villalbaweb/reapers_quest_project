using System.Collections;
using UnityEngine;

public class PlayerPowerupController : MonoBehaviour
{
    // config params
    [SerializeField] float powerUpTime = 20.0f;

    // cached items
    PowerUpParticleSystem _powerUpParticleSystem;

    // public prop
    public bool IsPowerupEnabled { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _powerUpParticleSystem = FindObjectOfType<PowerUpParticleSystem>();
        StopParticleSystem();
    }

    private void StartParticleSystem()
    {
        IsPowerupEnabled = true;
        _powerUpParticleSystem?.gameObject.SetActive(IsPowerupEnabled);
    }

    private void StopParticleSystem()
    {
        IsPowerupEnabled = false;
        _powerUpParticleSystem?.gameObject.SetActive(IsPowerupEnabled);
    }

    public void PowerUpStart()
    {
        StartCoroutine(PowerUp());
    }

    IEnumerator PowerUp()
    {
        StartParticleSystem();
        yield return new WaitForSecondsRealtime(powerUpTime);
        StopParticleSystem();
    }
}
