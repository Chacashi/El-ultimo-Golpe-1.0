using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector2 movementCamera;
    [SerializeField] private float velocity;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void MovementCamera(Vector2 value)
    {
        movementCamera += value * velocity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(-movementCamera.y, movementCamera.x, 0);
    }
    private void OnEnable()
    {
        InputReader.movementCamera += MovementCamera;
    }
    private void OnDisable()
    {
        InputReader.movementCamera -= MovementCamera;
    }
}
