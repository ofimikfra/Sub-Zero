using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    public float speed = 2f; // The speed at which the obstacle moves
    public float deadzone = -10;

    void Update()
    {
        // Move the obstacle horizontally
        transform.Translate(transform.TransformDirection(Vector3.left) * speed * Time.deltaTime);
    }

    private void FixedUpdate() 
    {
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object is the player
        if (other.CompareTag("Player"))
        {
            // Push the player back and prevent them from moving forward
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(-transform.right * speed, ForceMode.Impulse); // Use the negative x-axis
        }
    }
}

