using UnityEngine;

public class Swing : MonoBehaviour
{
    // config props
    [SerializeField] float initialSwingForce = 100f;

    // cache
    Rigidbody2D _swinggerRigidBody;

    public void StartSwing()
    {
        _swinggerRigidBody = GetComponent<Rigidbody2D>();
        Vector2 applyForce = new Vector2(initialSwingForce, _swinggerRigidBody.position.y);
        _swinggerRigidBody.AddForce(applyForce, ForceMode2D.Impulse);
    }
}
