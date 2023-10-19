using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private List<GameObject> playerProjectiles = new List<GameObject>();

    private List<GameObject> enemyProjectiles = new List<GameObject>();

    private List<GameObject> enemies = new List<GameObject> ();

    // Start might be used to dynamically add all game objects in a scene to this list

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count > 0 && playerProjectiles.Count > 0)
        {
            for (int i = 0; i < playerProjectiles.Count; i++)
            {
                SpriteInfo projectile = playerProjectiles[i].GetComponent<SpriteInfo>();

                for (int j = 0; j < enemies.Count; j++)
                {
                    SpriteInfo enemy = enemies[j].GetComponent<SpriteInfo>();

                    if (CircleCheck(projectile, enemy))
                    {
                        // projectile.isColliding = true;
                        // enemy.isColliding = true;

                        Destroy(playerProjectiles[i]);
                        Destroy(enemies[j]);

                        playerProjectiles.RemoveAt(i);
                        enemies.RemoveAt(j);

                        i--;
                        j--;
                    }
                }
            }
        }
    }

    private bool CircleCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        // Do circle check
        float a = spriteA.transform.position.x - spriteB.transform.position.x;
        float b = spriteA.transform.position.y - spriteB.transform.position.y;
        float c = spriteA.Radius + spriteB.Radius;

        if (a * a + b * b < c * c)
        {
            return true;
        }

        return false;
    }

    public void AddProjectile(GameObject newProjectile)
    {
        playerProjectiles.Add(newProjectile);
    }

    public void CleanUpProjectile(GameObject projectile)
    {
        // Occasionally the removal of projectiles results in a disappeared error, does not affect game but is unsolved
        int index = playerProjectiles.IndexOf(projectile);

        Destroy(projectile);

        playerProjectiles.RemoveAt(index);
    }

    public void CleanUp(GameObject gameObject, CollisionType listType)
    {
        int index = 0;

        switch(listType)
        {
            case CollisionType.enemy:
                index = enemies.IndexOf(gameObject);
                break;

            case CollisionType.player:
                // what do here??
                break;

            case CollisionType.playerProjectile:
                index = playerProjectiles.IndexOf(gameObject);
                break;

            case CollisionType.enemyProjectile:
                index = enemyProjectiles.IndexOf(gameObject);
                break;
        }

        Destroy(gameObject);

        playerProjectiles.RemoveAt(index);
    }

    public void AddEnemy(GameObject newEnemy)
    {
        enemies.Add(newEnemy);
    }
}