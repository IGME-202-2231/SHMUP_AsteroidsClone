using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    artillery,
    exploder,
    flotilla
}

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

    private EnemyType typeEnemy;

    void Start()
    {
        player = transform.parent.GetComponent<EnemySpawner>().GetTarget;
    }

    // Update is called once per frame
    void Update()
    {
        switch (typeEnemy)
        {
            case EnemyType.exploder:
                // charges towards the player to deal damage
                break;

            case EnemyType.flotilla:
                // moves across the screen, continuously shooting
                break;

            case EnemyType.artillery:
                // sits on the edge of the game area, shooting at the player
                break;
        }

        // Temporary movement
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

    public void SetEnemyType(EnemyType typeEnemy)
    {
        this.typeEnemy = typeEnemy;
    }
}
