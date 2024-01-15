using NavMeshPlus.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    public NavMeshSurface navMesh;
    public GameObject basement;
    [SerializeField]
    public float speed = 50f;
    public float speedPowerUp = 25f;
    public static bool alive;
    public static bool key;
    public static bool children;

    int randomVariable;


    public static bool escape;
    int RandomVariable;  

    
    // Start is called before the first frame update
    void Start()
    {
        
        alive = true;
        key = false;
        children = false;
        escape = false;
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

         rb.AddForce(movement * speed * Time.deltaTime, ForceMode2D.Impulse);

        if(Powerup.isPickedUp == true)
        {
            speed += speedPowerUp;

            Powerup.isPickedUp = false;
        }

        Debug.Log(speed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Santa"))
        {
            Destroy(gameObject);
            alive = false;
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
        if (collision.gameObject.name == ("basement") && key == true)
        {
            basement.transform.position = new Vector3(10000,0,0);
            children = true;
            key = false;
            navMesh.BuildNavMesh();
    
        }
        if (collision.gameObject.name == ("Exit") && children == true)
        {
            escape = true;
            Debug.Log("ohio");
            Destroy(gameObject);
            
        }

    }


    
}
