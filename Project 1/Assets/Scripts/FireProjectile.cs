using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private CollisionManager collisionManager;

    public CollisionManager CollisionManager
    {
        get { return collisionManager; }
    }

    public Transform Player
    { 
        get { return player; } 
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, player.position, player.rotation, transform);

        projectile.GetComponent<ProjectileController>().GiveInfo(collisionManager, player.gameObject.GetComponent<MovementController>().Direction);

        collisionManager.AddProjectile(projectile);
    }
}
