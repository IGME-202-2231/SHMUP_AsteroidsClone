using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    private float radius = 1f;

    [SerializeField]
    private int health = 1;

    /// <summary>
    /// Whether an object is experiencing a collision
    /// </summary>
    private bool isColliding = false;

    public bool IsColliding
    {
        set { isColliding = value; }
    }

    public float Radius
    {
        get { return radius; }
    }

    public int Health
    { 
        get { return health; } 
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            GetComponent<SpriteRenderer>().color = Color.red;

            health--;
        }

        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}