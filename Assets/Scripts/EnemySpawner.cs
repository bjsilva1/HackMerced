using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int spawnInterval = 1; 
    public int maxSpawnCount = 5;

    private float timer;
    private int spawnCount; 
    private int radius = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Public call to spawn enemies
    public void SpawnWave(int wave_num)
    {
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
        return 5;
    }

    private float calcSpawnDelay(int wave_num)
    {
        return 1;
    }


    private IEnumerator SpawnEnemies(int wave_num)
    {
        int num_spawns = calcNumSpawns(wave_num);
        float spawn_delay = calcSpawnDelay(wave_num);
        for (int i = 0; i < num_spawns; i++)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawn_delay);

            while (true)
            { 
                int curr_num_enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (curr_num_enemies < maxSpawnCount)
                    break;

                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private void SpawnObject()
    {
        float angle = Random.Range(-360f,360f);
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        Vector3 SpawnPosition = new Vector3(x, 0, z) + transform.position;

        Instantiate(enemy, SpawnPosition, Quaternion.identity); // Spawn the object at the spawner's position
    }
}
