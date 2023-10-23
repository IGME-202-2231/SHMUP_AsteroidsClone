using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private CollisionManager collisionManager;

    private Vector3 direction;

    private float speed;

    void Start()
    {
        // Here is where all my problems lie, behold and weep yee of fragile hearts
            // I was being dramatic, passing in the objects when they are spawned fixed it
        speed = 10.0f;

        StartCoroutine(gameObject.GetComponent<SpriteInfo>().Despawn(3.0f));
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void GiveInfo(CollisionManager collisionManager, Vector3 direction)
    {
        this.collisionManager = collisionManager;

        this.direction = direction;

        gameObject.GetComponent<SpriteInfo>().GetCollisions(collisionManager);
    }
}
