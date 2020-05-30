using System.Collections;
using UnityEngine;

public class PlayerPowerupController : MonoBehaviour
{
    [SerializeField] float powerUpTime = 20.0f;
    [SerializeField] bool isPowerupEnabled = false;

    PowerUpParticleSystem _powerUpParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        _powerUpParticleSystem = FindObjectOfType<PowerUpParticleSystem>();
        StopParticleSystem();
    }

    private void StartParticleSystem()
    {
        isPowerupEnabled = true;
        _powerUpParticleSystem?.gameObject.SetActive(isPowerupEnabled);
    }

    private void StopParticleSystem()
    {
        isPowerupEnabled = false;
        _powerUpParticleSystem?.gameObject.SetActive(isPowerupEnabled);
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
