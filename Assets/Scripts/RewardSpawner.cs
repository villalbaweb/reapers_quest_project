using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    // config params
    [SerializeField] GameObject rewardItem = null;
    [SerializeField] int numberOfItems = 10;
    [SerializeField] float maxXForceToSpawn = 10f;
    [SerializeField] float maxYForceToSpawn = 5f;

    public void StartSpawn()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            InstantiateItem();
        }
    }

    private void InstantiateItem()
    {
        GameObject item = Instantiate(rewardItem, transform.position, Quaternion.identity);

        Vector2 forceToAdd = new Vector2(Random.Range(-maxXForceToSpawn, maxXForceToSpawn), Random.Range(1, maxYForceToSpawn));

        item.GetComponent<Rigidbody2D>().AddForce(forceToAdd, ForceMode2D.Impulse);
    }
}
