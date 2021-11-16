using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private Vector3 moveDirection = Vector3.back;
    private Vector3 startPos;
    private float repeatPos;
    

    void Start()
    {
        startPos = transform.position;
        repeatPos = GameObject.Find("Water").GetComponent<Collider>().bounds.size.z / 2;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * moveDirection);

        if (transform.position.z < -repeatPos + 20)
        {
            transform.position = startPos;
        }
    }
}
