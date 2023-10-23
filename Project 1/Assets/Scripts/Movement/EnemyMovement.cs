using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 0.0f;

    [SerializeField]
    private float acceleration = 0.005f;

    [SerializeField]
    private float maxSpeed = 0.01f;

    private Vector3 velocity = Vector3.zero;

    private Vector3 direction = Vector3.zero;

    private Transform player;

    private 

    void Start()
    {
        player = transform.parent.GetComponent<EnemySpawner>().GetTarget;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector3 newDirection)
    {
        if (direction != null)
        {
            direction = newDirection.normalized;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
            }
        }
    }
}
