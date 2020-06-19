using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xMove = 10f, yMove = 10f;
    public float speed;
    private float minX = -8f, maxX = 8f, minY = 4.5f, maxY = -2.5f;
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



        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;
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
        //Vector3 pos = transform.position;
        //pos.x = Mathf.Clamp(pos.x, minX, maxX);
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
        //transform.position = pos;
    }

    void Move()
    {
        newVelocity = new Vector2(xMove, yMove);
        rb.velocity = newVelocity;
    }

}
