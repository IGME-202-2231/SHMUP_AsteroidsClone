using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;

    [SerializeField]
    ProjectileController projectileController;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementController.SetDirection(context.ReadValue<Vector2>());
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            projectileController.SetDirection(movementController.Direction);

            // Should fire the bullet
                // creates a bullet

                    // needs a direction
                // adds it to any CollisionManager lists


        }
    }

}
