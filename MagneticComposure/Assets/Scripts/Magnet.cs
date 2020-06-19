using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public bool attract, repel, occupied = false;
    public float moveSpeed, step;
    private Vector3 targetPosition;
    private GameObject objectInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step = moveSpeed * Time.deltaTime;
        targetPosition = transform.position;
        CheckInput();
    }

    void CheckInput()
    {
        if (objectInRange != null)
        { 
            if (Input.GetMouseButton(0))
            {
                attract = true;
                repel = false;

                objectInRange.transform.position = Vector3.MoveTowards(objectInRange.transform.position, new Vector3(targetPosition.x, objectInRange.transform.position.y, objectInRange.transform.position.z), step / (objectInRange.GetComponent<Rigidbody2D>().drag) * 10);
                //objectInRange.transform.up = targetPosition - objectInRange.transform.position;
            }
            else if (Input.GetMouseButton(1))
            {
                attract = false;
                repel = true;

                if (objectInRange.transform.position.x < transform.position.x)
                {
                    targetPosition.x = -11.0f;
                }
                else
                {
                    targetPosition.x = 11.0f;
                }

                objectInRange.transform.position = Vector3.MoveTowards(objectInRange.transform.position, new Vector3(targetPosition.x, objectInRange.transform.position.y, objectInRange.transform.position.z), step / (objectInRange.GetComponent<Rigidbody2D>().drag) * 10);

            }
            else
            {
                attract = false;
                repel = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Positive" || (col.gameObject.tag == "Negative"))
        {
            if (!occupied)
                objectInRange = col.gameObject;
            else
                occupied = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Positive" || (col.gameObject.tag == "Negative"))
        {
            if (occupied)
                occupied = false;
        }
    }
}
