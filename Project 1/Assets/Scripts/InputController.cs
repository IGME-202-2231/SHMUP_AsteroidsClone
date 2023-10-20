using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class InputController : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;

    [SerializeField]
    FireProjectile projectileSpawner;

    public void OnBoost(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movementController.EnableBoost = true;
        }

        if (context.performed)
        {
            movementController.EnableBoost = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.SetDirection(context.ReadValue<Vector2>());
    }

    public void OnLook()
    {

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            projectileSpawner.Fire();
        }
    }

}
