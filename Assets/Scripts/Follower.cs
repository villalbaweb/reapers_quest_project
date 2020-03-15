using UnityEngine;

public class Follower : MonoBehaviour
{
    // config params
    [SerializeField] float speed = 5f;
    [SerializeField] bool followEnabled = true;
    [SerializeField] public Transform target;

    // Update is called once per frame
    void Update()
    {
        if(followEnabled)
            Follow();
        else
            MoveForeward();
    }

    private void Follow()
    {
        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, CalculateStep());
    }

    private void MoveForeward()
    {
        //Get the direction vector between A and B
        Vector3 Direction = transform.position - target.position;
        //Normalize it
        Direction.Normalize();
        //Translate along the direction
        transform.Translate(Direction * CalculateStep());
    }

    private float CalculateStep()
    {
        return speed * Time.deltaTime;
    }
}
