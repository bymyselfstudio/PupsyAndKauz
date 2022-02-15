using UnityEngine;

public class DespawnArea : MonoBehaviour
{
    // implement in GameManager script
    // make dependend on visible area, no collision detection needed
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
