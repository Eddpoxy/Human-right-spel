using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed = 50;
    public static bool alive;
    public static bool key;
    int randomVariable; 
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        key = false;
        rb = GetComponent<Rigidbody2D>();
        randomVariable = Random.Range(0, 4);
        
        Debug.Log("Present (" + randomVariable + ")");
    }

    // Update is called once per frame
    void Update()
    { 
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

            rb.AddForce(movement * speed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Santa"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name.Contains("Present"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == ("Present (" + randomVariable + ")"))
        {
            Destroy(collision.gameObject);
            key = true;
        }
    }

}
