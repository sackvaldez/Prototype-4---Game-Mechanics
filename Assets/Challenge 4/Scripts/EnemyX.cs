using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private float initialSpeed;
    private GameObject playerGoal;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        initialSpeed = speed;
    }

    public void ResetSpeed()
    {
        speed = initialSpeed; // Restablece la velocidad al valor inicial
    }

    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal" || other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}
