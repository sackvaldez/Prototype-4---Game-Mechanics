using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public float speed = 5.0f;
    private float powerupStrength = 15.0f;
    public bool hasPowerup;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // We get the input from the player
        float forwardInput = Input.GetAxis("Vertical");
        // We add movement to the player in the forward direction of the focal point
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        // We move the powerup indicator to the player's position
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    // We create a method to add powerup effects to the player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            // With setActive we can enable or disable the powerup indicator
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            // We start the coroutine below to make the powerup last for a limited time
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
//    // In order to make the powerup last for a limited time, 
//    we create a coroutine that will set hasPowerup to false after 7 seconds
    IEnumerator PowerupCountdownRoutine()
    {
        // Yield is a keyword that is used to return an IEnumerator, so we can use it in a coroutine
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // We get the rigidbody component of the enemy and the direction of the player from the enemy
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            // We push the enemy away from the player with a force of powerupStrength
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Player collided with: " + collision.gameObject + " with powerup set to " + hasPowerup);
        }
    }
    
} 
