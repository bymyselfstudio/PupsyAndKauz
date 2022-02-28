using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Tooltip("Heart prefab must be last index!")]
    [SerializeField] GameObject[] obstablePrefabs;
    public GameManager gameManager;
    private readonly float xRange = 8.0f;
    private readonly float zRangeMax = 80.0f;
    private readonly float zRangeMin = 60.0f;
    public float ySpawnPosition = 0.55f;
    

    void Start()
    {
        InvokeRepeating("RandomSpawnItem", gameManager.firstSpawnDelay, gameManager.spawnRepeatTime);
    }

    private void RandomSpawnItem()
    {
        if (gameManager.Health == 100)
        {
            // Heart doesn't spawn, if health = 100. Prefab has to be last index in list!
            int itemIndex = Random.Range(0, obstablePrefabs.Length - 1);
            Instantiate(obstablePrefabs[itemIndex], RandomSpawnPosition(), obstablePrefabs[itemIndex].transform.rotation);
        }
        else if (gameManager.Health < 100)
        {
            int itemIndex = Random.Range(0, obstablePrefabs.Length);
            Instantiate(obstablePrefabs[itemIndex], RandomSpawnPosition(), obstablePrefabs[itemIndex].transform.rotation);
        }
    }
    
    private Vector3 RandomSpawnPosition()
    {
        float xSpawnPos = Random.Range(-xRange, xRange);
        float zSpawnPos = Random.Range(zRangeMin, zRangeMax);
        Vector3 spawnPos = new Vector3(xSpawnPos, ySpawnPosition, zSpawnPos);
        return spawnPos;
    }

    

}
