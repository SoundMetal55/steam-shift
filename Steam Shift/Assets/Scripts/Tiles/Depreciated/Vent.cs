using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Steam")
        {
            Debug.Log("vent entered");
            collision.transform.GetComponent<Steam>().colliders.Add("Vent");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Steam")
        {
            collision.transform.GetComponent<Steam>().colliders.Remove("Vent");
            if (collision.transform.GetComponent<Steam>().colliders.Contains("Vent"))
            {
                Debug.Log("vent exited");
            }
        }
    }
    */
}
