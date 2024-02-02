using NavMeshPlus.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
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

    [SerializeField]
    public float speed = 50f;
    public float speedPowerUp = 25f;
    public static bool alive;
    public static bool key;
    public static bool children;
    
    public AudioSource santa;
    public AudioSource walk;
    public AudioSource door;
    bool gameover;
    Vector2 moveInput;
   
    public static bool escape; 
    static public int randomVariablePowerSpeed;
    static public int randomVariablePowerLight;
    static public int randomVariable;
    Light2D playerlight;
  
    // Start is called before the first frame update
    void Start()
    {
        playerlight = GetComponent<Light2D>();
        animator = GetComponent<Animator>();
        gameover = false;
        alive = true;
        key = false;
        children = false;
        escape = false;
        rb = GetComponent<Rigidbody2D>();
        RandomVariables();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude); 
        if (Powerup.isPickedUp == true)
        {
            speed += speedPowerUp;

            Powerup.isPickedUp = false;
        } 
        

    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Present (" + randomVariablePowerSpeed + ")"))
        {
            speed *= 2;
            Invoke("powerup", 25f);
         
        }
        if (collision.gameObject.name == ("Present (" + randomVariablePowerLight + ")"))
        {
            playerlight.pointLightOuterRadius *= 2;
            Invoke("lightPower", 35f);
          
        }
        if (collision.gameObject.name == ("Present (" + randomVariable + ")"))
        {
            
            key = true;
        }
        if (collision.gameObject.name == ("Santa"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(winner);
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
    void MovePlayer()
    {
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
    }

    void powerup()
    {
        speed /= 2; 
    }
    void lightPower()
    {
        playerlight.pointLightOuterRadius /= 2;
    }
    void RandomVariables()
    {
        randomVariable = Random.Range(0, 10);
        randomVariablePowerSpeed = Random.Range(0, 10);
        randomVariablePowerLight = Random.Range(0, 10);
        Debug.Log("Present (" + randomVariablePowerSpeed + ")");
        Debug.Log("Present (" + randomVariablePowerLight + ")");
        Debug.Log("Present (" + randomVariable + ")");
    }

}

