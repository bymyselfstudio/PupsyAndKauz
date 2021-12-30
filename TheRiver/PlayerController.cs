using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float xRangeCorrection = 1.8f;
    [SerializeField] Camera mainCamera;
    private float xRange;
    private float horizontalMovement;
    private readonly float xPlayerSpeed = 18;
    private readonly float leaningAngle = 12.5f;
    private Transform kayak;


    private void Awake()
    {
        xRange = GameObject.Find("Water").GetComponent<Collider>().bounds.size.x / 2;
        kayak = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        // maybe better performance with rigidbody and FixedUpdate()
        transform.Translate(new Vector3(horizontalMovement, 0, 0) * xPlayerSpeed * Time.deltaTime, Space.World);
        
        SetKayakToBounds();
        LeaningKayak();
    }

    void LateUpdate()
    {
        Vector3 cameraOffset = new Vector3(0, 6.5f, -54);
        mainCamera.transform.SetPositionAndRotation(transform.position + cameraOffset, Quaternion.Euler(35, transform.rotation.y, transform.rotation.z));
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

    void LeaningKayak()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            kayak.transform.Rotate(Vector3.forward * -leaningAngle, Space.Self);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            kayak.transform.Rotate(Vector3.forward * leaningAngle, Space.Self);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            kayak.transform.Rotate(Vector3.forward * leaningAngle, Space.Self);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            kayak.transform.Rotate(Vector3.forward * -leaningAngle, Space.Self);
        }
    }
}
