// OBSOLETE! 

using UnityEngine;

public class DespawnArea : MonoBehaviour
{
    // implemented in GeneralObstacleHandler & GeneralCollectableHandler
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
