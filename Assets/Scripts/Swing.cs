using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    // config props
    [SerializeField] float initialSwingForce = 100f;

    // cache
    Rigidbody2D _bladeRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _bladeRigidBody = GetComponent<Rigidbody2D>();

        Vector2 applyForce = new Vector2(initialSwingForce, _bladeRigidBody.position.y);
        _bladeRigidBody.AddForce(applyForce, ForceMode2D.Impulse);
    }
}
