using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    [SerializeField]
    private float radius = 1f;

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

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
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