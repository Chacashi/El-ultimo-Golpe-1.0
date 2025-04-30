using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> movementCamera;
    public static event Action<Vector2> movementPlayer;
    public void MovementCamera(InputAction.CallbackContext context)
    {
        movementCamera?.Invoke(context.ReadValue<Vector2>());
    }
    public void MovementPlayer(InputAction.CallbackContext context)
    {
        movementPlayer?.Invoke(context.ReadValue<Vector2>());
    }
}
