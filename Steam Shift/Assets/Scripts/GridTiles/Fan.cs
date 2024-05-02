using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Engineer")
        {
            Debug.Log("fan entered");
            collision.transform.GetComponent<Engineer>().colliders.Add("Fan");
            collision.transform.GetComponent<Engineer>().isFloating = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Engineer")
        {
            collision.transform.GetComponent<Engineer>().colliders.Remove("Fan");
            if (collision.transform.GetComponent<Engineer>().colliders.Contains("Fan"))
            {
                Debug.Log("fan exited");
                collision.transform.GetComponent<Engineer>().isFloating = false;
            }
        }
    }
}
