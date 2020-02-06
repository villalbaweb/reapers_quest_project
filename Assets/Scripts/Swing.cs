using System;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class Sswing : MonoBehaviour
{
    // config props
    [SerializeField] float initialSwingForce = 100f;

    // cache
    Rigidbody2D _bladeRigidBody;
    EnemyHealth _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        _bladeRigidBody = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<EnemyHealth>();

        _enemyHealth.OnDie += OnSwingerDie;

        Vector2 applyForce = new Vector2(initialSwingForce, _bladeRigidBody.position.y);
        _bladeRigidBody.AddForce(applyForce, ForceMode2D.Impulse);
    }

    private void OnSwingerDie()
    {
        Destroy(gameObject);
    }
}
