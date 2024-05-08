using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("pipe entered");
        if (collision.tag == "Steam")
        {
            Debug.Log("pipe entered");
            collision.transform.GetComponent<Steam>().colliders.Add("Pipe");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Steam")
        {
            collision.transform.GetComponent<Steam>().colliders.Remove("Pipe");
            if (collision.transform.GetComponent<Steam>().colliders.Contains("Pipe"))
            {
                Debug.Log("pipe exited");
            }
        }
    }
}
