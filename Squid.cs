using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : MonoBehaviour
{
    public float size;
    public float moveSpeed;
    public float health;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
	public float frequency;
	public float magnitude;
    bool facingRight = true;

    void Start()
    {
        size = Random.Range(0.1f,0.2f);
        transform.localScale = new Vector2(size,size);
        rb = GetComponent<Rigidbody2D>();

        if (size >=0.15)
        {
            moveSpeed = 5f;
        }
        else if (size < 0.15)
        {
            moveSpeed = 6f;
        }

        pos = transform.position;
		localScale = transform.localScale;

        frequency = Random.Range(0.5f,5f);
        magnitude = Random.Range(0.5f,5.5f);
    }


	Vector3 pos, localScale;

	// Update is called once per frame
	void Update () 
    {
		CheckWhereToFace ();

		if (facingRight)
			MoveRight ();
		else
			MoveLeft ();
	}

	void CheckWhereToFace()
	{
		if (pos.x < -7f)
			facingRight = true;
		
		else if (pos.x > 7f)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;

	}

	void MoveRight()
	{
		pos += transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

	void MoveLeft()
	{
		pos -= transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

}
