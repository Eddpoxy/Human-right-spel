using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moovement = new Vector2(horizontalInput, verticalInput).normalized;
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(5 , 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-5, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, 5));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0, -5));
        }
    } 
}
