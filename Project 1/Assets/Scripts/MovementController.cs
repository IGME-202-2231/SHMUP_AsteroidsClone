using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private bool enableBoost;

    private float speed = 0.0f;

    [SerializeField]
    private float acceleration = 2.0f;

    [SerializeField]
    private float maxSpeed = 0.8f;

    private Vector3 velocity = Vector3.zero;

    private Vector3 objectPosition = Vector3.zero;
    private Vector3 direction = Vector3.zero;

    private float cameraHeight;
    private float cameraWidth;

    public Vector3 Direction
    { 
        get { return direction; } 
    }

    public bool EnableBoost
    {
        set { enableBoost = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // begins as true for now while point direction is NOT implemented
        // once implemented in tandem with space-boost, can remove from start
        enableBoost = true;

        // Prevents teleporting to Vector3.zero
        objectPosition = transform.position;

        cameraHeight = Camera.main.orthographicSize;

        cameraWidth = cameraHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableBoost)
        {
            speed += acceleration;

            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }

            velocity += direction * speed * Time.deltaTime;
        }

        objectPosition += velocity;

        // Check Position; if using collisions, need to make sure object isn't in a restricted area before moving it
        if (objectPosition.y + GetComponent<SpriteInfo>().Radius > cameraHeight)
        {
            objectPosition.y = cameraHeight - GetComponent<SpriteInfo>().Radius;
        }

        if (objectPosition.y - GetComponent<SpriteInfo>().Radius < -cameraHeight)
        {
            objectPosition.y = -cameraHeight + GetComponent<SpriteInfo>().Radius;
        }

        if (objectPosition.x + GetComponent<SpriteInfo>().Radius > cameraWidth)
        {
            objectPosition.x = cameraWidth - GetComponent<SpriteInfo>().Radius;
        }

        if (objectPosition.x - GetComponent<SpriteInfo>().Radius < -cameraWidth)
        {
            objectPosition.x = -cameraWidth + GetComponent<SpriteInfo>().Radius;
        }

        // Updates the actual object's position
        transform.position = objectPosition;
    }

    public void SetDirection(Vector3 newDirection)
    {
        if (direction != null)
        {
            direction = newDirection.normalized;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
            }
        }
    }

    /// <summary>
    /// Uses the old version of active input rather than the newer input system
    /// Need to move this code into input controller, add to the look event
    /// </summary>
    public void PointDirection()
    {
        // The direction 
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // Converting the angle to degrees
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = rotation;
    }
}
