using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;
        transform.up = direction;
    }
}
