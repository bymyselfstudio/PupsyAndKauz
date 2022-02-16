using UnityEngine;

public class DespawnArea : MonoBehaviour
{
    // implement in SpawnManager script
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
