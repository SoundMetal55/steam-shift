using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ladder entered");
        if (other.transform.GetComponent<Engineer>() != null)
        {
            Debug.Log("ladder entered");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.GetComponent<Engineer>() != null)
        {
            Debug.Log("ladder exited");
        }
    }
}
