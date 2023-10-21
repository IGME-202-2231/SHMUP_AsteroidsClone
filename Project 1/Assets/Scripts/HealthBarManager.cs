using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageHUD : MonoBehaviour
{
    [SerializeField]
    SpriteInfo playerInfo;

    private float maxHealth;

    private Vector3 objectScale;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = playerInfo.Health;

        objectScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(objectScale.x * (playerInfo.Health / maxHealth), objectScale.y, objectScale.z);
    }
}
