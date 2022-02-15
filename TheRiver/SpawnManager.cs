using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // implement in GameManager
    // implement levelKey spawn when level score is reached
    // implement method which checks if heartPrefab is active, so no other heart should spawn

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
        // work with coroutine instead!
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

    // IMPLEMENT LATER WHEN HEARTS CAN BE COLLECTED
    //IEnumerator BulletproofCooldown()
    //{
    //    yield return new WaitForSeconds(5);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    StartCoroutine(BulletproofCooldown());
    //}
}
