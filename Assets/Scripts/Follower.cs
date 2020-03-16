using UnityEngine;

public class Follower : MonoBehaviour
{
    // config params
    [Tooltip("Follower' Speed")]
    [SerializeField] float speed = 5f;
    [Tooltip("Time after the instantion that will keep following (-1 Infinite)")]
    [SerializeField] float followTime = -1f;
    [Tooltip("Follower's Target")]
    [SerializeField] public Transform target;

    // state
    float executedFollowTime = 0f;

    // Update is called once per frame
    void Update()
    {
        float step = CalculateStep();

        if (IsFollowing())
        {
            CalculateTargetPOsition(step);
        }

        MoveRight(step);
    }

    private void MoveRight(float step)
    {
        transform.position += transform.right * step;
    }

    private void CalculateTargetPOsition(float step)
    {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, step);
    }

    private bool IsFollowing()
    {
        executedFollowTime += Time.deltaTime;
        return followTime < 0 || executedFollowTime < followTime;
    }

    private float CalculateStep()
    {
        return speed * Time.deltaTime;
    }
}
