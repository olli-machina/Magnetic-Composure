using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xMove = 10f;
    public float speed;
    float yMove = 10f;
    Rigidbody2D rb;
    public Vector2 newVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    void CheckInput()
    {
        xMove = Input.GetAxis("Horizontal") * speed;
        yMove = Input.GetAxis("Vertical") * speed;
    }

    void Move()
    {
        newVelocity = new Vector2(xMove, yMove);
        rb.velocity = newVelocity;
    }

}
