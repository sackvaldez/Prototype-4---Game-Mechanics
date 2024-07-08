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
        // We get the direction of the player from the enemy and it is normalized to have a magnitude of 1
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        // We add force to the enemy in the direction of the player and with the speed value
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);

    }
}
