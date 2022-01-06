using UnityEngine;


public class GeneralCollectableHandler : MonoBehaviour 
{
	enum CollectableTypes { NoType, Health, Score, LevelKey, FinalKey, PowerUp, NegativeBuff };
	[SerializeField] CollectableTypes collectableType; // this gameObject's type

	[SerializeField] bool rotate = true; // do you want it to rotate?
	[SerializeField] bool move = true; // do you want it to move?

	[SerializeField] Vector3 rotationCenterAxis = Vector3.up; // edit for another center axis
	[SerializeField] Vector3 movementDirection = Vector3.back; // edit for another direction

	[SerializeField] float rotationSpeed = 50f;
	[SerializeField] float movementSpeed = 20f;

	[SerializeField] AudioClip collectSfx;
	[SerializeField] GameObject collectParticles;

	private GameManager gameManager;


    private void Awake()
    {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update() 
	{
		if (rotate)
			transform.Rotate (rotationSpeed * Time.deltaTime * rotationCenterAxis, Space.Self);
		if (move)
			transform.Translate(movementSpeed * Time.deltaTime * movementDirection, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player")) 
			Collect();
	}

	private void Collect()
	{
		if(collectSfx)
			AudioSource.PlayClipAtPoint(collectSfx, transform.position);
		if(collectParticles)
			Instantiate(collectParticles, transform.position, Quaternion.identity);

        switch (collectableType)
        {
            case CollectableTypes.NoType:
				//Add in code here;
				Debug.Log("Do NoType Command");
				Destroy(gameObject);
				break;
            case CollectableTypes.Health:
				gameManager.AddHealth(20);
				Destroy(gameObject);
				break;
            case CollectableTypes.Score:
				gameManager.AddScore(15);
				Destroy(gameObject);
				break;
            case CollectableTypes.LevelKey:
				Debug.Log("You got the Level Key!");
				Destroy(gameObject);
				break;
            case CollectableTypes.FinalKey:
				//Add in code here;
				Debug.Log("Do FinalKey Command");
				Destroy(gameObject);
				break;
            case CollectableTypes.PowerUp:
				//Add in code here;
				Debug.Log("Do PowerUp Command");
				Destroy(gameObject);
				break;
			case CollectableTypes.NegativeBuff:
				//Add in code here;
				Debug.Log("Do NegativeBuff Command");
				Destroy(gameObject);
				break;
        }

    }
}
