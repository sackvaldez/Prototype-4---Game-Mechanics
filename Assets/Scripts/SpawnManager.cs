using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // We create a public GameObject variable to store the enemy prefab
    public GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        // We instantiate the enemy prefab at the position (0, 0, 0) with the rotation of the prefab
        Instantiate(enemyPrefab, new Vector3(0, 0, 0), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
