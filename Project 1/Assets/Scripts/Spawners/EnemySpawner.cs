using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private TextMesh waveKeeper;

    [SerializeField]
    private Transform playerTarget;

    [SerializeField]
    private GameObject[] enemyPrefabs = new GameObject[3];

    [SerializeField]
    private CollisionManager collisionManager;

    private float halfHeight;

    private float halfWidth;

    /// <summary>
    /// The time between a wave being defeated and the start of a new one
    /// </summary>
    private const float waveTimer = 2.0f;

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
    private int enemyWaveTotal;

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

        spawnTimer = 5.2f;
        enemyWaveTotal = 3;
        enemyReserves = enemyWaveTotal;
        waveNumber = 0;

        StartCoroutine(NextWave());
    }

    void Update()
    {
        if (enemyReserves <= 0 && collisionManager.EnemyCount <= 0)
        {
            StartCoroutine(NextWave());
        }

        if (!playerTarget.gameObject.activeSelf)
        {
            waveKeeper.gameObject.SetActive(true);

            waveKeeper.transform.localScale /= 3;

            waveKeeper.text = "Final Score: " + collisionManager.Score + "\nThank you for playing!";

            gameObject.SetActive(false);
        }
    }

    private IEnumerator WhenToSpawn()
    {
        yield return new WaitForSeconds(spawnTimer);

        if (enemyReserves > 0 && playerTarget.gameObject.activeSelf)
        {
            enemyReserves--;

            int randomSide = Random.Range(0, 4);
            int enemyType = Random.Range(0, enemyPrefabs.Length);

            Spawn(randomSide, enemyType);

            StartCoroutine(WhenToSpawn());
        }
    }

    private IEnumerator NextWave()
    {
        if (waveNumber != 0)
        {
            spawnTimer -= 0.2f;
            enemyWaveTotal += 5;
            enemyReserves = enemyWaveTotal;

            collisionManager.Score += 100;
        }

        waveNumber++;

        waveKeeper.gameObject.SetActive(true);

        waveKeeper.text = "Wave: " + waveNumber;

        yield return new WaitForSeconds(waveTimer);

        waveKeeper.gameObject.SetActive(false);

        StartCoroutine(WhenToSpawn());

    }

    // Its not the most effective way to spawn the flotilla, best case would be to have a single create method that could be cycled through x number of times
        // starting position would be calculated based on the side, and dividing by this x variable
        // not sure how to get around the two switch blocks, perhaps x variable could divide the starting position by 2, simply becuase there is one enemy
        // additional enemies would divide the start pos. by the number of enemies being spawned
        // TLDR; create a spawning method around spawning multiple enemies, then spawning for a single enemy would be much easier
    public void Spawn(int side, int enemyType)
    {
        Vector3 startPosition = Vector3.zero;

        int numIterations = 1;

        // This if statement will do while only the flotilla prefab has a different number of enemies spawning - this may change when making waves more difficult
        if (enemyType == 2) 
        {
            numIterations = 3;
        }

        for (int i = 1; i < numIterations + 1; i++)
        {
            switch (side)
            {
                case 0: // Left
                    startPosition.x = -halfWidth;
                    startPosition.y = halfHeight - ( (2 * halfHeight * i) / (numIterations + 1) );
                    break;

                case 1: // Up
                    startPosition.x = halfWidth - ( (2 * halfWidth * i) / (numIterations + 1) );
                    startPosition.y = halfHeight;
                    break;

                case 2: // Right
                    startPosition.x = halfWidth;
                    startPosition.y = halfHeight - ( (2 * halfHeight * i) / (numIterations + 1) );
                    break;

                case 3: // Down
                    startPosition.x = halfWidth - ( (2 * halfWidth * i) / (numIterations + 1) ); 
                    startPosition.y = -halfHeight;
                    break;
            }

            GameObject newEnemy = Instantiate(enemyPrefabs[enemyType], startPosition, Quaternion.identity, transform);

            newEnemy.GetComponent<SpriteInfo>().GetCollisions(collisionManager);

            collisionManager.AddCollidable(newEnemy, newEnemy.GetComponent<SpriteInfo>().CollisionType);
        }
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