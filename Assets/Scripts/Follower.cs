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
        float step = CalculateStep();

        if(followEnabled)
            Follow(step);

        transform.position += transform.right * step;
    }

    private void Follow(float step)
    {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, step);
    }

    private float CalculateStep()
    {
        return speed * Time.deltaTime;
    }
}
