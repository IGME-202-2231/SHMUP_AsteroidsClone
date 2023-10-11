using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private List<SpriteInfo> collidables = new List<SpriteInfo>();

    [SerializeField]
    private TextMesh collisionType;

    // Start might be used to dynamically add all game objects in a scene to this list

    // Update is called once per frame
    void Update()
    {
        // loop through to see if anything is colliding with player's vehicle
        // still seems wildly inefficient, is there a better way? - object pooling
        collidables[0].IsColliding = false;

        foreach (var coll in collidables)
        {
            coll.IsColliding = false;

            if (CircleCheck(collidables[0], coll) && collidables[0] != coll)
            {
                coll.IsColliding = true;
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
}