using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> movementCamera;
    public static event Action<Vector2> movementPlayer;
    public static event Action shootEvent;
    public static event Action reloadEvent;
    public void MovementCamera(InputAction.CallbackContext context)
    {
        movementCamera?.Invoke(context.ReadValue<Vector2>());
    }
    public void MovementPlayer(InputAction.CallbackContext context)
    {
        movementPlayer?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
            shootEvent?.Invoke();
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed)
            reloadEvent?.Invoke();
    }
}
