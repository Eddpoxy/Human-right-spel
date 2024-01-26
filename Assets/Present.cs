using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public GameObject text;
    public GameObject shoe;
    public GameObject lightbulb;
    public AudioSource tear;
    movement movement; 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Player"))
        {
            
            if (gameObject.name != ("Present (" + movement.randomVariable + ")") && gameObject.name != ("Present (" + movement.randomVariablePowerSpeed + ")") && gameObject.name != ("Present (" + movement.randomVariablePowerLight + ")"))
            {
                Instantiate(text, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                tear.Play();
                Destroy(gameObject);
            }

            if (gameObject.name == ("Present (" + movement.randomVariablePowerSpeed + ")"))
            {


                Instantiate(shoe, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                tear.Play();
                Destroy(gameObject);
            }
            if (gameObject.name == ("Present (" + movement.randomVariablePowerLight + ")"))
            {

                Instantiate(lightbulb, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                tear.Play();
                Destroy(gameObject);
            }
        }

    }
}
