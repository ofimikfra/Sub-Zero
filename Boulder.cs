using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public float size;
    public float health;
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        size = Random.Range(0.1f,0.25f);
        transform.localScale = new Vector2(size,size);
        rb = GetComponent<Rigidbody2D>();

        if (size >= 0.2f) //big
        {
            speed = -2.5f;
        }
        else if (size >= 0.15f & size < 0.2f) //medium
        {
            speed = -3f;
        }
        else if (size < 0.15f) //small
        {
            speed = -4f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,0,40)*Time.deltaTime);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
