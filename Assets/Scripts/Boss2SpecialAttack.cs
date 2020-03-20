using UnityEngine;

public class Boss2SpecialAttack : MonoBehaviour
{
    // config params
    [SerializeField] GameObject projectile = null;

    // State
    GameObject _projectileParent;

    const string PROJECTILE_PARENT_NAME = "Boss2 Projectiles";

    // Start is called before the first frame update
    void Start()
    {
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        _projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (!_projectileParent)
        {
            _projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }
    private void FireBallAttackAnimationEvent()
    {
        Follower followerObject = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Follower>();
        followerObject.target = FindObjectOfType<Player>().transform;

        followerObject.transform.parent = _projectileParent.transform;
    }
}
