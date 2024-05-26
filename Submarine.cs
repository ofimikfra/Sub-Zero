using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Submarine : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    private Vector2 moveInpt;
    public float speed;
    public float health;
    public GameObject explode;
    public Logic logic;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject clone = Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(clone,0.5f);
            alive = false;
            logic.gameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            TakeDamage(1);
        }
    }

    private void FixedUpdate() 
    {
        rb.velocity = moveInpt*speed;
    }

    private void OnMove(InputValue inputvalue)
    {
        moveInpt = inputvalue.Get<Vector2>();
    }

    private void OnFire()
    {
        Instantiate(bulletPrefab,shootingPoint.position,transform.rotation);
    }
}
