using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform playerTarget;

    [SerializeField]
    private SpriteRenderer[] enemyPrefabs = new SpriteRenderer[3];

    [SerializeField]
    private CollisionManager collisionManager;

    private float halfHeight;

    private float halfWidth;

    /// <summary>
    /// The time between a wave being defeated and the start of a new one
    /// </summary>
    private float waveTimer;

    /// <summary>
    /// The time between enemies being spawned into the scene
    /// </summary>
    private float spawnTimer;

    /// <summary>
    /// The number of enemies yet to be spawned into a wave
    /// </summary>
    private int enemyReserves;

    /// <summary>
    /// The total number of enemies spawned during a wave
    /// </summary>
    private int waveCount;

    /// <summary>
    /// The current wave being faced
    /// </summary>
    private int waveNumber;

    /// <summary>
    /// Allows the player object to be passed to newly created enemies
    /// </summary>

    public Transform GetTarget
    {  
        get { return playerTarget; } 
    }

    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;

        halfWidth = halfHeight * Camera.main.aspect;

        waveTimer = 5.0f;

        spawnTimer = 5.0f;

        enemyReserves = 0;

        waveCount = 0;

        waveNumber = 0;

        StartCoroutine(WhenToSpawn());
    }

    public void Spawn()
    {
        int enemyType = Random.Range(0, enemyPrefabs.Length); // int Range max is exclusive

        int side = Random.Range(0, 4);

        float normalPosition = Random.Range(-1.0f, 1.0f);

        Vector3 startPosition = Vector3.zero;

        switch(side)
        {
            case 0: // Left
                startPosition.x = -halfWidth;
                startPosition.y = halfHeight * normalPosition;
                break;

            case 1: // Up
                startPosition.x = halfWidth * normalPosition;
                startPosition.y = halfHeight;
                break;

            case 2: // Right
                startPosition.x = halfWidth;
                startPosition.y = halfHeight * normalPosition;
                break;

            case 3: // Down
                startPosition.x = halfWidth * normalPosition;
                startPosition.y = -halfHeight;
                break;
        }

        collisionManager.AddEnemy(Instantiate(enemyPrefabs[enemyType], startPosition, Quaternion.identity, transform));

        // some error here, prevents the object from being cast, may be a result in the unity instead
    }


    private IEnumerator WhenToSpawn()
    {
        yield return new WaitForSeconds(spawnTimer);

        Spawn();

        StartCoroutine(WhenToSpawn());
    }

    // Instantiate a new enemy COMPLETE
        // choose between a couple of prefabs, some random 1d4
        // choose between 4 sides, another random 1d4
        // random float between (-1,1)

    // When to spawn a new enemy DONE
        // spawn timer variable: betweenSpawn DONE
            // could be random
            // or could start out slow and increase over time
         
        // Wait for seconds coroutine? DONE
            // instantiate new enemy, keep all this in a Spawn() method DONE

    // Keep track of wave mechanic variables DONE
        // the total number of enemies for this wave: waveCount DONE
        // the number of enemies left to spawn this wave: enemyReserves DONE
        // the list of enemies in the scene: enemies DONE
            // use .Count to compare with enemyReserves
        // the wave number DONE

    // possible wave mechanics
        // when .Count and enemyReserves == 0; increase the waveCount, reset enemyReserves, decrease betweenSpawns
        // waitforseconds between wave, display wave number using canvas: betweenWave
        // waitforseconds between spawn times: betweenSpawn 
        
}
