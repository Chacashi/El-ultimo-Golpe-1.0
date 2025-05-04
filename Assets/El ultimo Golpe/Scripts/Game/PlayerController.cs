using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movementInput;
    [SerializeField] private float velocity;
    [SerializeField] private Transform cameraTransform; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void MovementPlayer(Vector2 value)
    {
        movementInput = value;
    }
    private void FixedUpdate()
    {
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movementDirection = cameraRight * movementInput.x + cameraForward * movementInput.y;

        rb.linearVelocity = new Vector3(movementDirection.x * velocity, rb.linearVelocity.y, movementDirection.z * velocity);
    }
    private void OnEnable()
    {
        InputReader.movementPlayer += MovementPlayer;
    }
    private void OnDisable()
    {
        InputReader.movementPlayer -= MovementPlayer;
    }
}
