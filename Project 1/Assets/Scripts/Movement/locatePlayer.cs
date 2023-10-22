using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class locatePlayer : MonoBehaviour
{
    private float speed = 0.0f;

    [SerializeField]
    private float acceleration = 0.005f;

    [SerializeField]
    private float maxSpeed = 0.01f;

    private Vector3 velocity = Vector3.zero;

    private Vector3 direction = Vector3.zero;

    private Transform player;

    private void Start()
    {
        player = transform.parent.GetComponent<EnemySpawner>().GetTarget;
    }

    private void Update()
    {
        if (player.gameObject.activeSelf)
        {
            SetDirection(player.transform.position - transform.position);
        }

        speed += acceleration;

        if (speed > maxSpeed)
        {
            speed = maxSpeed; 
        }

        velocity += direction * speed * Time.deltaTime;

        transform.position += velocity;
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

    /*
     *SetDirection()
     * Vector3 direction = (player.transform.position - trnasform.position);
     * direction.normalized;
     * desired = direction * maxspeed
     * 
     * Vector3 steer = desired - velocity
     * 
     * steer.limit(maxForce);
     * 
     * acceleration += steer;
     * 
     * 
     * New Variables ---
     *  velocity.add(acceleration);
        velocity.limit(maxspeed);
        location.add(velocity);
        acceleration.mult(0);
     */
}
