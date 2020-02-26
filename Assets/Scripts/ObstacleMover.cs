using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // config params
    [SerializeField] bool moveRight = true;
    [SerializeField] float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() 
    {
        Vector2 directionVector = moveRight ? Vector2.right : Vector2.left;

        transform.Translate(directionVector * speed * Time.deltaTime, Space.World);    
    }
}
