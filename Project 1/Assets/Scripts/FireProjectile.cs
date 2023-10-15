using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer projectile;

    private List<SpriteRenderer> projectiles = new List<SpriteRenderer>();

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        projectiles.Add(Instantiate(projectile, transform.position, transform.rotation));
    }
}
