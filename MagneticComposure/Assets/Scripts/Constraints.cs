using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Positive" || col.gameObject.tag == "Negative")
        {
            if (gameObject.name == "Boundary")
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
            }
            else if (name == "DestroyWord")
            {
                Destroy(col.gameObject);
            }
        }
    }
}
