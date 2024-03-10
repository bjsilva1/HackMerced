using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public VRHUDController hudController;
    public PlayerHealth playerHealth;

    GameObject[] enemySpawners;
    int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        currentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int curr_num_enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (EnemySpawner.spawningFinished && curr_num_enemies == 0)
        {
            ++currentWave;
            foreach (GameObject s in enemySpawners)
            {
                s.GetComponent<EnemySpawner>().SpawnWave(currentWave);
            }
        }


        // UI update
        hudController.showNextWave(currentWave);
        hudController.setHealth(playerHealth.getHealth());
        hudController.setScore(currentWave);
    }
}
