using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 0.2f;

    [SerializeField]
    private float speed = 0.0f;

    [SerializeField]
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float maxSpeed = 1.0f;

    private Vector3 objectPosition = Vector3.zero;
    private Vector3 direction = Vector3.zero;

    private float cameraHeight;
    private float cameraWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Prevents teleporting to Vector3.zero
        objectPosition = transform.position;

        cameraHeight = Camera.main.orthographicSize;

        cameraWidth = cameraHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed * Time.deltaTime ) 
        { 
            speed = maxSpeed * Time.deltaTime;
        }

        velocity += direction * speed;

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
}
