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
    public bool isColliding {  get; set; }

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
            health--;
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
}