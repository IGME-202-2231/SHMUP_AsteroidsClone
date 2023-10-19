using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionType
{
    enemy,
    player,
    enemyProjectile,
    playerProjectile
}


public class SpriteInfo : MonoBehaviour
{
    private CollisionManager collisionManager;

    // The below fields are all determined by their prefab, so no need to set them to variables during start
    [SerializeField]
    private CollisionType collisionType;

    [SerializeField]
    private float radius = 1f;

    [SerializeField]
    private int health = 1;

    /// <summary>
    /// Whether an object is experiencing a collision
    /// </summary>
    public bool isColliding {  get; set; }

    public float Radius
    {
        get { return radius; }
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            health--;
        }

        if (health <= 0) // To be used in Collision manager w/ isColliding to replace current collision setup
        {
            collisionManager.CleanUp(gameObject, collisionType);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Damage()
    {
        health--;
    }

    /// <summary>
    /// These getinfo methods grab info when an object is instantiated, but could easily be removed if singletons were used
    /// </summary>
    /// <param name="collisionManager"></param>
    public void GetCollisions(CollisionManager collisionManager)
    {
        this.collisionManager = collisionManager;
    }
}