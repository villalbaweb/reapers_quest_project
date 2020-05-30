using UnityEngine;

public class PlayerPowerupController : MonoBehaviour
{
    [SerializeField] bool IsPowerupEnabled = false;

    PowerUpParticleSystem _powerUpParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        _powerUpParticleSystem = FindObjectOfType<PowerUpParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        _powerUpParticleSystem?.gameObject.SetActive(IsPowerupEnabled);
    }
}
