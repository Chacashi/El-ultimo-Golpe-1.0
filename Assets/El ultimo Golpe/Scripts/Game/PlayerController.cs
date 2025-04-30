using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movementPlayer;
    [SerializeField] private float velocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void MovementPlayer(Vector2 value)
    {
        movementPlayer = value;
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(movementPlayer.x * velocity, rb.linearVelocity.y, movementPlayer.y * velocity);
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
