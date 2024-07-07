using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    void Start()
    {
        // We get the rigidbody component of the enemy
        enemyRb = GetComponent<Rigidbody>();
        // We get the player object with the name "Player"
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // We add force to the enemy in the direction of the player and with the speed value
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        
    }
}
