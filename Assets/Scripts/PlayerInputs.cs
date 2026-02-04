using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputs : MonoBehaviour
{
    public Vector2 _move;
    
    public Vector2 _look;

    public float _interact;

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _look = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        _interact = context.ReadValue<float>();
    }
}
