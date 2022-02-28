using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float xRangeCorrection = 3f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject water;
    private float xRange;
    private float horizontalMovement;
    private readonly float tiltAngle = 12f;
    private float cameraRotationX = 33;
    private Vector3 cameraOffset = new Vector3(0, 2.4f, -4.7f);
    private GameManager gameManager;
    private AudioSource poleInWater;


    private void Awake()
    {
        xRange = water.GetComponent<Collider>().bounds.size.x / 2;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        poleInWater = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        // maybe better performance with rigidbody and FixedUpdate()
        transform.Translate(gameManager.xPlayerSpeed * Time.deltaTime * new Vector3(horizontalMovement, 0, 0), Space.World);
        
        SetKayakToBounds();

        // should not happen before game is started!
        TiltKayak();
    }

    void LateUpdate()
    {
        mainCamera.transform.SetPositionAndRotation(transform.position + cameraOffset, Quaternion.Euler(cameraRotationX, transform.rotation.y, transform.rotation.z));
    }

    void SetKayakToBounds()
    {
        if (transform.position.x < (-xRange + xRangeCorrection))
            transform.position = new Vector3(-xRange + xRangeCorrection, transform.position.y, transform.position.z);
        else if (transform.position.x > (xRange - xRangeCorrection))
            transform.position = new Vector3(xRange - xRangeCorrection, transform.position.y, transform.position.z);
    }

    void TiltKayak()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate((Vector3.forward * -tiltAngle), Space.Self);
            poleInWater.Play();
        }
            
        else if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * tiltAngle, Space.Self);
            poleInWater.Play();
        }
           
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * tiltAngle, Space.Self);
            poleInWater.Play();
        }
            
        else if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * -tiltAngle, Space.Self);
            poleInWater.Play();
        }     
    }
}
