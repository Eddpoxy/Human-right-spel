using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    Rigidbody2D rb;
    public float offset;
    public Transform target;
    public int speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction from the current position to the target position
        Vector2 direction = target.position - transform.position;

        // Normalize the direction vector to have a magnitude of 1
        direction.Normalize();

        // Calculate the movement vector based on the direction and speed
        Vector2 movement = direction * speed * Time.deltaTime;

        // Move the object towards the target
        transform.Translate(movement);

    }
}
