using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class locatePlayer : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;

    [SerializeField]
    Transform playerTransform;

    private void Update()
    {
        movementController.SetDirection(playerTransform.position - transform.position);
    }
}
