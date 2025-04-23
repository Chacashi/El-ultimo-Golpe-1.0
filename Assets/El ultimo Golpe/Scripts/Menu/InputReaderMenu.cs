using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class InputReaderMenu : MonoBehaviour
{
    PlayerInput playerInput;
    public static event Action OnPressedSpace;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void  OnTransition(InputAction.CallbackContext context)
    {
        context.ReadValue<bool>();
        OnPressedSpace.Invoke();
    }

}
