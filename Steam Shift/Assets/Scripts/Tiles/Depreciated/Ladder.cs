using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    //handing collision here was a mistake. going back to handling colliders in the player class for now but it should eventually be put into a different script from movement.
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Engineer")
        {
            Debug.Log("ladder entered");
            collision.transform.GetComponent<Engineer>().colliders.Add("Ladder");
            collision.transform.GetComponent<Engineer>().isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Engineer")
        {
            collision.transform.GetComponent<Engineer>().colliders.Remove("Ladder");
            if (collision.transform.GetComponent<Engineer>().colliders.Contains("Ladder"))
            {
                Debug.Log("ladder exited");
                collision.transform.GetComponent<Engineer>().isClimbing = false;
            }
        }
    }
    */
}
