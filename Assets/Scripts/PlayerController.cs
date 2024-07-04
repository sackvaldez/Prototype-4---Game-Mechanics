using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;
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
    }
} 
