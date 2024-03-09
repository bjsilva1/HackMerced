using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class EnemySpawner : MonoBehaviour
{
    public int maxSpawnCount = 5;
    public int radius = 5;
    public GameObject[] enemyPrefabs;

    private float timer;
    private int spawnCount;

    private const int BASIC = 0;
    private const int TANK = 1;
    private const int FAST = 2;

    public static bool spawningFinished;
    // Start is called before the first frame update
    void Start()
    {
        spawningFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Public call to spawn enemies
    public void SpawnWave(int wave_num)
    {
        spawningFinished = false;
        StartCoroutine(SpawnEnemies(wave_num));
    }

    //----------------------
    //   Private functions
    //----------------------

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }

    private int calcNumSpawns(int wave_num)
    {
        return (int) (wave_num * wave_num / 9) + 5;
    }

    private float calcSpawnDelay(int wave_num)
    {
        float calc = 2 - 0.1f * (wave_num / 2);
        return calc < 0.2f ? 0.2f : calc;
    }

    private int generateEnemyType(int wave_num)
    {
        if (wave_num < 4)
        {
            return BASIC;
        }
        else if (wave_num < 10)
        {
            float randomNum = Random.Range(0, 10f);
            return randomNum < 1 ? TANK : BASIC;
        }
        else if (wave_num < 20)
        {
            float randomNum = Random.Range(0, 10f);
            if (randomNum < 2)
                return BASIC;
            else if (randomNum < 7)
                return TANK;
            else
                return FAST;
        }
        else
        {
            float randomNum = Random.Range(0, 11f);
            if (randomNum < 1)
                return BASIC;
            else if (randomNum < 6)
                return TANK;
            else
                return FAST;
        }
    }


    private IEnumerator SpawnEnemies(int wave_num)
    {
        int num_spawns = calcNumSpawns(wave_num);
        float spawn_delay = calcSpawnDelay(wave_num);
        for (int i = 0; i < num_spawns; i++)
        {
            SpawnObject(generateEnemyType(wave_num));
            yield return new WaitForSeconds(spawn_delay);

            while (true)
            { 
                int curr_num_enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (curr_num_enemies <= maxSpawnCount)
                    break;

                yield return new WaitForSeconds(0.5f);
            }
        }
        spawningFinished = true;
    }

    private void SpawnObject(int enemyType)
    {
        float angle = Random.Range(-360f,360f);
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        Vector3 SpawnPosition = new Vector3(x, 0, z) + transform.position;

        Instantiate(enemyPrefabs[enemyType], SpawnPosition, Quaternion.identity); // Spawn the object at the spawner's position
    }
}
