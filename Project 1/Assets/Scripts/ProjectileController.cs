using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 direction;

    private float speed;

    private float projectileDespawn;

    private CollisionManager collisionManager;

    private MovementController movementController;

    void Start()
    {
        // Here is where all my problems lie, behold and weep yee of fragile hearts
        collisionManager = transform.parent.GetComponent<FireProjectile>().CollisionManager;

        movementController = transform.parent.gameObject.GetComponent<MovementController>();

        speed = 5.0f;

        direction = movementController.Direction;

        projectileDespawn = 3.0f;

        StartCoroutine(Despawn());
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(projectileDespawn);

        // transform.parent.GetComponent<FireProjectile>().Eliminate(transform.GetComponent<SpriteRenderer>());

        // transform.GetComponent<SpriteInfo>().Damage();

        collisionManager.CleanUpProjectile(gameObject);
    }
}
