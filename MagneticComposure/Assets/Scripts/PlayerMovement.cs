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
    Camera cam;

    void Awake()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        CheckInput();
        // convert mouse position into world coordinates
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
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
