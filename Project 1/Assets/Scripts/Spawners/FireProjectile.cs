using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject playerProjectile;

    [SerializeField] 
    private GameObject enemyProjectile;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private CollisionManager collisionManager;

    public void Fire()
    {
        GameObject projectile = Instantiate(playerProjectile, player.position, player.rotation, transform);

        projectile.GetComponent<ProjectileController>().GiveInfo(collisionManager, player.gameObject.GetComponent<MovementController>().Direction);

        collisionManager.AddCollidable(projectile, projectile.GetComponent<SpriteInfo>().CollisionType);
    }

    public void Fire(Transform host)
    {
        GameObject projectile = Instantiate(enemyProjectile, host.position, host.rotation, transform);

        projectile.GetComponent<ProjectileController>().GiveInfo(collisionManager, host.gameObject.GetComponent<EnemyMovement>().Direction);

        collisionManager.AddCollidable(projectile, projectile.GetComponent<SpriteInfo>().CollisionType);
    }

}
