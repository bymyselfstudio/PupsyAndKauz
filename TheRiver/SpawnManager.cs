using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] obstablePrefabs;
    private GameManager gameManager;
    private readonly float xRange = 8.0f;
    private readonly float zRangeMax = 80.0f;
    private readonly float zRangeMin = 60.0f;
    private readonly float firstSpawnDelay = 0.5f;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    void Start()
    {
        InvokeRepeating("RandomSpawnItem", firstSpawnDelay, gameManager.spawnRepeatTime);
    }

    private void RandomSpawnItem()
    {
        int itemIndex = Random.Range(0, obstablePrefabs.Length);
        Instantiate(obstablePrefabs[itemIndex], RandomSpawnPosition(), obstablePrefabs[itemIndex].transform.rotation);
    }
    
    private Vector3 RandomSpawnPosition()
    {
        // several models don't match the local unity orientation, so spawnpos is not set correctly! => was fixed due setting right prefabs location
        float ySpawnPos = ((float)Space.Self); // only works with correct local orientation!
        float xSpawnPos = Random.Range(-xRange, xRange);
        float zSpawnPos = Random.Range(zRangeMin, zRangeMax);
        Vector3 spawnPos = new Vector3(xSpawnPos, ySpawnPos, zSpawnPos);
        return spawnPos;
    }
}
