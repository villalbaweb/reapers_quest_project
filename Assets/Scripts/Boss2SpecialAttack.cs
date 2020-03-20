using UnityEngine;

public class Boss2SpecialAttack : MonoBehaviour
{
    // config params
    [SerializeField] GameObject projectile = null;

    private void FireBallAttackAnimationEvent()
    {
        Follower followerObject = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Follower>();
        followerObject.target = FindObjectOfType<Player>().transform;
    }
}
