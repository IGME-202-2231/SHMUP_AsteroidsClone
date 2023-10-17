using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private CollisionManager collisionManager;

    public CollisionManager CollisionManager
    {
        get { return collisionManager; }
    }

    public void Fire()
    {
        Vector3 position = transform.position;

        Quaternion rotation = transform.rotation;

        collisionManager.AddProjectile(Instantiate(projectile, position, rotation, transform));
    }
}
