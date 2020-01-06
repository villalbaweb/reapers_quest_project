using System.Collections;
using UnityEngine;

public class EnemyDieHandler : MonoBehaviour
{
    // config params
    [SerializeField] float timeToDestroyAfterDeath = 0.5f;

    // cache
    CapsuleCollider2D _mainBodyCollider2D;
    BoxCollider2D _feetCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        _mainBodyCollider2D = GetComponent<CapsuleCollider2D>();
        _feetCollider2D = GetComponent<BoxCollider2D>();
    }

    public void HandleDeath() 
    {
        StartCoroutine(DieVFX());
    }


    IEnumerator DieVFX()
    {
        if (_mainBodyCollider2D)
        {
            _mainBodyCollider2D.enabled = false;
        }

        if (_feetCollider2D)
        {
            _feetCollider2D.enabled = false;
        }

        yield return new WaitForSeconds(timeToDestroyAfterDeath);
        Destroy(gameObject);
    }

}
