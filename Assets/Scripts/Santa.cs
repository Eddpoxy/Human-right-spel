using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Santa : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    movement movement;


    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
     if (movement.children == true)
        {
            agent.speed = 4.5f;
        }
    } 
  
}
