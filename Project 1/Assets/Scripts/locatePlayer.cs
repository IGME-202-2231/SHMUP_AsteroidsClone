using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class locatePlayer : MonoBehaviour
{
    [SerializeField]
    MovementController movementController;

    Transform player;

    private void Start()
    {
        player = transform.parent.GetComponent<EnemySpawner>().GetTarget;
    }

    private void Update()
    {
        movementController.SetDirection(player.transform.position - transform.position);
    }
}
