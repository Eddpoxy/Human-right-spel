using NavMeshPlus.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;



public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    public string winner;
    public Animator animator;
    public NavMeshSurface navMesh;
    public GameObject basement;
    public GameObject text;
    public GameObject shoe;
    [SerializeField]
    public float speed = 50f;
    public float speedPowerUp = 25f;
    public static bool alive;
    public static bool key;
    public static bool children;
    public AudioSource tear;
    public AudioSource santa;
    public AudioSource walk;
    public AudioSource door;
    bool gameover;
    Vector2 moveInput;
   
    public static bool escape;
    int randomVariablePower;
    int randomVariable;
    float horizontalMove = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameover = false;
        alive = true;
        key = false;
        children = false;
        escape = false;
        rb = GetComponent<Rigidbody2D>();
        randomVariable = Random.Range(0, 10);
        randomVariablePower = Random.Range(0, 10);
        Debug.Log("Present (" + randomVariablePower + ")");
        Debug.Log("Present (" + randomVariable + ")");
    }

    // Update is called once per frame
    void Update()
    {
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude); 
        if (gameover != true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            rb.AddForce(movement * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
      

       
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        { 
            if (!walk.isPlaying)
            {
                walk.Play();
            }
           
        }  
        else
        {
            walk.Stop();
        }
      
        
     

        if (Powerup.isPickedUp == true)
        {
            speed += speedPowerUp;

            Powerup.isPickedUp = false;
        } 
        

    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Santa"))
        {
           
            alive = false;
            gameover = true;
            santa.Play();
            Invoke("powerup", 5f);
        }
        if (collision.gameObject.name.Contains("Present"))
        {
            Destroy(collision.gameObject);
            if (collision.gameObject.name != "Present (" + randomVariable + ")" && collision.gameObject.name != ("Present (" + randomVariablePower + ")"))
            Instantiate(text, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            tear.Play();
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
           Invoke("powerup", 25f);
            Instantiate(shoe, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }

        if (collision.gameObject.name == ("basement") && key == true)
        {
            TilemapCollider2D basementCollision = basement.GetComponent<TilemapCollider2D>();
            NavMeshModifier basementaicollision = basement.GetComponent<NavMeshModifier>();
            door.Play();
            basementaicollision.area = 0;
            basementCollision.enabled = false;
            children = true;
            key = false;
            navMesh.BuildNavMesh();
    
        }
        if (collision.gameObject.name == ("Exit") && children == true)
        {
            escape = true;

            SceneManager.LoadScene(winner);

        }

    }

        
    void powerup()
    {
        speed /= 2; 
        if (gameover == true)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
 
}

