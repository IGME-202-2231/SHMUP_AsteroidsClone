using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private CollisionManager collisionManager;

    private Vector3 direction;

    private float speed;

    private float projectileDespawn;

    void Start()
    {
        // Here is where all my problems lie, behold and weep yee of fragile hearts
        // collisionManager = transform.parent.GetComponent<FireProjectile>().CollisionManager;

        // direction = transform.parent.gameObject.GetComponent<FireProjectile>().Player.gameObject.GetComponent<MovementController>().Direction;

        speed = 5.0f;

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

    public void GiveInfo(CollisionManager collisionManager, Vector3 direction)
    {
        this.collisionManager = collisionManager;
        this.direction = direction;
    }
}
