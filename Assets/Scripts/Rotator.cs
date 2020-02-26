using UnityEngine;

public class Rotator : MonoBehaviour
{
    // config params
    [SerializeField] [Range(-7200f, 7200f)] float rotation = 3600f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotation * Time.deltaTime, Space.World);
    }
}
