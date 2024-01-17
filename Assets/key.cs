using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    movement movement;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.key == true)
        {
            transform.position = new Vector3(player.transform.position.x + -0.5f, player.transform.position.y, -1 );
        } 
        else
        {
            transform.position = new Vector2(10000000,1000000000);
        }

    
    }
  
   
}
