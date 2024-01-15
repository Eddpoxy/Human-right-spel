using NavMeshPlus.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;



public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public NavMeshSurface navMesh;
    public GameObject basement;
    public GameObject text;
    [SerializeField]
    public float speed = 50f;
    public float speedPowerUp = 25f;
    public static bool alive;
    public static bool key;
    public static bool children;
    private Vector2 moveInput;

    public static bool escape;
    int randomVariablePower;
    int randomVariable;  
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        alive = true;
        key = false;
        children = false;
        escape = false;
        rb = GetComponent<Rigidbody2D>();
        randomVariable = Random.Range(0, 4);
        randomVariablePower = Random.Range(0, 4);
        Debug.Log("Present (" + randomVariablePower + ")");
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
            
            
            Instantiate(text, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            
        }
        if (collision.gameObject.name == ("Present (" + randomVariable + ")"))
        {
            Destroy(collision.gameObject);
            key = true;
        } 
        else
        
        if (collision.gameObject.name == ("Present (" + randomVariablePower + ")"))
        { 
           speed *= 2;
           Invoke("powerup", 5f);
        }

        if (collision.gameObject.name == ("basement") && key == true)
        {
            TilemapCollider2D basementCollision = basement.GetComponent<TilemapCollider2D>();
            NavMeshModifier basementaicollision = basement.GetComponent<NavMeshModifier>();
         
            basementaicollision.area = 0;
            basementCollision.enabled = false;
            children = true;
            key = false;
            navMesh.BuildNavMesh();
    
        }
        if (collision.gameObject.name == ("Exit") && children == true)
        {
            escape = true;
            
            Destroy(gameObject);
            
        }

    }
    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            
        }
    }
    void powerup()
    {
        speed /= 2;
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();  
        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
        }
     
    }
}

