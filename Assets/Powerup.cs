using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public static bool isPickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Picked up PowerUp");

        isPickedUp = true;
        Destroy(this.gameObject);
    }
    
}
