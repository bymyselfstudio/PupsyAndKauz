using UnityEngine;

public class GeneralObstacleHandler : MonoBehaviour
{
    enum ObstacleTypes { NoType, Rock, Can, WoodPile, Barrel, Sealillie };
    [SerializeField] ObstacleTypes obstacleType; // this gameObject's type

    [SerializeField] bool rotate = false;
    [SerializeField] bool move = true;

    [SerializeField] float rotationSpeed = 100;
    [SerializeField] float movementSpeed = 12;

    [SerializeField] Vector3 rotationCenterAxis = Vector3.up;
    [SerializeField] Vector3 movementDirection = Vector3.back;

    [SerializeField] AudioClip obstacleCrash;
    [SerializeField] GameObject crashParticles;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (rotate)
            transform.Rotate(rotationSpeed * Time.deltaTime * rotationCenterAxis, Space.Self);
        if (move)
            transform.Translate(movementSpeed * Time.deltaTime * movementDirection, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Crash();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DespawnArea"))
            Destroy(gameObject);
    }

    void Crash()
    {
        if (obstacleCrash)
            AudioSource.PlayClipAtPoint(obstacleCrash, transform.position, 1.5f);
        if (crashParticles)
            Instantiate(crashParticles, transform.position, Quaternion.identity);

        switch (obstacleType)
        {
            case ObstacleTypes.NoType:
                break;
            case ObstacleTypes.Rock:
                gameManager.AddHealth(-20);
                break;
            case ObstacleTypes.Can:
                gameManager.AddHealth(-5);
                break;
            case ObstacleTypes.WoodPile:
                gameManager.AddHealth(-10);
                break;
            case ObstacleTypes.Barrel:
                gameManager.AddHealth(-20);
                break;
            case ObstacleTypes.Sealillie:
                gameManager.AddHealth(-5);
                break;
        }
    }
}
