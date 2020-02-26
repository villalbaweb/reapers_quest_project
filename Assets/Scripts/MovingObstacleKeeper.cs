using UnityEngine;

public class MovingObstacleKeeper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ObstacleMover mover = other.gameObject.GetComponent<ObstacleMover>();

        if (mover == null) return;

        if (mover.bounceOnCollide)
        {
            mover.moveRight = !mover.moveRight;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
