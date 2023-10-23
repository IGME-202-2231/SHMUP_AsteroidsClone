using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    exploder,
    flotilla,
    artillery
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

    private EnemyType enemyType;

    void Start()
    {
        player = transform.parent.GetComponent<EnemySpawner>().GetTarget;

        switch (enemyType)
        {
            case EnemyType.exploder:
                speed = 5;
                break;

            case EnemyType.flotilla:
                speed = 4;
                StartCoroutine(gameObject.GetComponent<SpriteInfo>().Despawn());
                break;

            case EnemyType.artillery:
                speed = 1;
                StartCoroutine(Halt());
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case EnemyType.exploder:
                // charges towards the player to deal damage

                if (player.gameObject.activeSelf)
                {
                    SetDirection(player.transform.position - transform.position);
                }


                transform.position += direction * speed * Time.deltaTime;

                break;

            case EnemyType.flotilla:
                // moves across the screen, continuously shooting

                transform.position += direction * speed * Time.deltaTime;

                break;

            case EnemyType.artillery:
                // sits on the edge of the game area, shooting at the player

                if (player.gameObject.activeSelf)
                {
                    SetDirection(player.transform.position - transform.position);
                }

                transform.position += direction * speed * Time.deltaTime;

                break;
        }
    }

    private void SetDirection(Vector3 newDirection)
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

    private IEnumerator Halt()
    {
        yield return new WaitForSeconds(1);

        speed = 0;
    }

    public void SetEnemyType(EnemyType enemyType, Vector3 direction)
    {
        this.enemyType = enemyType;
        
        this.direction = direction;
    }
}
