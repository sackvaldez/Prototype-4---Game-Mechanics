using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int waveCount = 1;

    private EnemyX enemyXScript;
    public GameObject player;

    void Start()
    {
        enemyXScript = enemyPrefab.GetComponent<EnemyX>();
        ResetGame(); // Restablece el juego al comenzar
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        waveCount++;
        // Increase enemy speed each level
        enemyXScript.speed += 1.0f;
        ResetPlayerPosition(); // put player back at start
    }

    void ResetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void ResetGame()
    {
        // Restablece la velocidad de todos los enemigos al valor inicial
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            EnemyX enemyScript = enemy.GetComponent<EnemyX>();
            if (enemyScript != null)
            {
                enemyScript.ResetSpeed();
            }
        }

        // Restablece otras variables de juego según sea necesario
        waveCount = 1;
        enemyXScript.ResetSpeed(); // Restablece la velocidad del enemigo inicial
    }
}
