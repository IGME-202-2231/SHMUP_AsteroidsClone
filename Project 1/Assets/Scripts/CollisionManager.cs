using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private List<SpriteInfo> collidables = new List<SpriteInfo>();

    // Start might be used to dynamically add all game objects in a scene to this list

    // Update is called once per frame
    void Update()
    {
        // loop through to see if anything is colliding with player's vehicle
        // still seems wildly inefficient, is there a better way? - object pooling
        collidables[0].IsColliding = false;

        for (int i = 0; i < collidables.Count; i++)
        {
            // Unable to use, as this would alter the number of items in the list, making the rest of the loop not function
            // Unless this were at the end of the loop, then i-- would fix the order
            // but then items would collide for 2 frames instead of 1, no good
            /*if (collidables[i].Health <= 0)
            {
                Destroy(collidables[i].gameObject);

                collidables.RemoveAt(i);
            }*/

            collidables[i].IsColliding = false;

            if (CircleCheck(collidables[0], collidables[i]) && collidables[0] != collidables[i])
            {
                collidables[i].IsColliding = true;
                collidables[0].IsColliding = true;
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

    public void NewBullet(ProjectileController sample)
    {
        collidables.Add()
    }
}