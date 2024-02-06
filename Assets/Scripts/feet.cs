using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("text", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void text()
    {
        Destroy(gameObject);
    }
}
