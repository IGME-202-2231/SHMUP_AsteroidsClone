using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private Vector3 velocity = Vector3.zero;

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
        velocity = direction * speed * Time.deltaTime;

        objectPosition += velocity;

        // Check Position; if using collisions, need to make sure object isn't in a restricted area before moving it
        if (objectPosition.y > cameraHeight)
        {
            objectPosition.y = cameraHeight;
        }

        if (objectPosition.y < -cameraHeight)
        {
            objectPosition.y = -cameraHeight;
        }

        if (objectPosition.x > cameraWidth)
        {
            objectPosition.x = cameraWidth;
        }

        if (objectPosition.x < -cameraWidth)
        {
            objectPosition.x = -cameraWidth;
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
