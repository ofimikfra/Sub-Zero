using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explode;
    public float health;
    public float deadzone = -10;

    private void Start() 
    {
        health = Random.Range(1,3);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject clone = Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(clone,0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag.Equals("Player") == true)
        {
            GameObject clone = Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(clone, 0.5f);
        }
    }

    // Start is called before the first frame update

    private void FixedUpdate() 
    {
        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }
    
}
