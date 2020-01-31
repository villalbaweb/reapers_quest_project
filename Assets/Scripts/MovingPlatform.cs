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
        if(movingPath != null) {
            if (AtWaypoint()) {
                movingPathWaypointIndex = movingPath.NextPosition(movingPathWaypointIndex);
            }
        }

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, movingPath.GetPathpoint(movingPathWaypointIndex), step);
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
