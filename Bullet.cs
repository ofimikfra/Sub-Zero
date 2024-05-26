using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject explode;
    public float deadzone = 15;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*speed;
        transform.Rotate(0, 0, -90);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (!collision.gameObject.tag.Equals("Player") && !collision.gameObject.tag.Equals("Barrier"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
            GameObject clone = Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(clone, 0.5f);
        }
    }

    void Update()
    {
        if (transform.position.x > deadzone)
        {
            Destroy(gameObject);
        }
    }
}
