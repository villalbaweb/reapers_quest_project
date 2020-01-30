using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        other.transform.SetParent(null);   
    }
}
