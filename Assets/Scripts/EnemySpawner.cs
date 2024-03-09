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
        timer += Time.deltaTime;
        if (timer >= spawnInterval && spawnCount < maxSpawnCount)
        {
            SpawnObject();
            timer = 0; // Reset the timer
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }
    private void SpawnObject()
    {
        float angle = Random.Range(-360f,360f);
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        Vector3 SpawnPosition = new Vector3(x, 0, z) + transform.position;

        Instantiate(enemy, SpawnPosition, Quaternion.identity); // Spawn the object at the spawner's position
        spawnCount++; // Increment the spawn count
    }
}
