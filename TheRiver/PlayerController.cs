using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float xRangeCorrection = 1.8f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject water;
    private Transform kayak;
    private float xRange;
    private float horizontalMovement;
    private readonly float xPlayerSpeed = 18;
    private readonly float tiltAngle = 12.5f;
    private float cameraRotationX = 35;
    private Vector3 cameraOffset = new Vector3(0, 6, -8);
    private GameManager gameManager;


    private void Awake()
    {
        xRange = water.GetComponent<Collider>().bounds.size.x / 2;
        kayak = GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        // maybe better performance with rigidbody and FixedUpdate()
        transform.Translate(xPlayerSpeed * Time.deltaTime * new Vector3(horizontalMovement, 0, 0), Space.World);

        SetKayakToBounds();

        // should not happen before game is started!
        TiltKayak(gameManager.isStopwatchRunning);
    }

    void LateUpdate()
    {
        mainCamera.transform.SetPositionAndRotation(transform.position + cameraOffset, Quaternion.Euler(cameraRotationX, transform.rotation.y, transform.rotation.z));
    }

    void SetKayakToBounds()
    {
        if (transform.position.x < (-xRange + xRangeCorrection))
        {
            transform.position = new Vector3(-xRange + xRangeCorrection, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > (xRange - xRangeCorrection))
        {
            transform.position = new Vector3(xRange - xRangeCorrection, transform.position.y, transform.position.z);
        }
    }

    void TiltKayak(bool _isStopwatchRunning)
    {
        if (_isStopwatchRunning)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                kayak.transform.Rotate(Vector3.forward * -tiltAngle, Space.Self);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                kayak.transform.Rotate(Vector3.forward * tiltAngle, Space.Self);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                kayak.transform.Rotate(Vector3.forward * tiltAngle, Space.Self);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                kayak.transform.Rotate(Vector3.forward * -tiltAngle, Space.Self);
            }
        }
        else
        {
            return;
        }

    }
}
