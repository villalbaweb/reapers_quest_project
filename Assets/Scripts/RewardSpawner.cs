using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    // config params
    [SerializeField] GameObject rewardItem = null;
    [SerializeField] int numberOfItems = 10;

    public void StartSpawn()
    {
        print($"number of items {numberOfItems} of {rewardItem.name}");
        for (int i = 0; i < numberOfItems; i++)
        {
            InstantiateItem();
        }
    }

    private void InstantiateItem()
    {
        Instantiate(rewardItem, transform.position, Quaternion.identity);
    }
}
