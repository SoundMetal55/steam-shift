using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public bool isOn;
    // fan will be interactable by the steam spirit to turn it on or off, but for now im low on time so it will make it into next build

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Steam")
        {
            Debug.Log("fan entered");
            isOn = true;
        }

        if (collision.tag == "Engineer")
        {
            Debug.Log("fan entered");
            collision.transform.GetComponent<Engineer>().colliders.Add("Fan");
            collision.transform.GetComponent<Engineer>().isFloating = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Steam")
        {
            isOn = false;
        }

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
