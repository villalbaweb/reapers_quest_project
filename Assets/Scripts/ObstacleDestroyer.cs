using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(other.gameObject);    
    }
}
