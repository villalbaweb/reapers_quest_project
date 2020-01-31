using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // config
    [SerializeField] MovingPlatformPath movingPath = null;
    [SerializeField] float waypointTolerance = 0.1f;
    [SerializeField] float speed = 1f;

    // state
    int movingPathWaypointIndex = 0;

    private void Update()
    {
        PathHandler();
        MovePlatform();
    }

    private void MovePlatform()
    {
        transform.position = Vector2.MoveTowards(transform.position, movingPath.GetPathpoint(movingPathWaypointIndex), speed * Time.deltaTime);
    }

    private void PathHandler()
    {
        if (movingPath != null)
        {
            if (AtWaypoint())
            {
                movingPathWaypointIndex = movingPath.NextPosition(movingPathWaypointIndex);
            }
        }
    }

    private bool AtWaypoint()
    {
        float distanceToWaypoint = Vector2.Distance(transform.position, movingPath.GetPathpoint(movingPathWaypointIndex));
        return distanceToWaypoint < waypointTolerance;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        other.transform.SetParent(null);   
    }
}
