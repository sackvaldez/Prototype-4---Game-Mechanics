using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // We create a public GameObject variable to store the enemy prefab
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int waveNumber = 1;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        // We get the number of enemies in the scene
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            // We spawn a new wave of enemies when there are no enemies in the scene
            SpawnEnemyWave(waveNumber);
        }
    }

    // We create a method to spawn a wave of enemies with a parameter to define the number of enemies to spawn
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
        // We instantiate the enemy prefab at a randomPos variable position using a for loop
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


// We create a method to generate a random spawn position for the enemy
    Vector3 GenerateSpawnPosition()
    {
        // We get a random position on the x and z axis within the spawn range
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        // We store the random position in a Vector3 variable
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
