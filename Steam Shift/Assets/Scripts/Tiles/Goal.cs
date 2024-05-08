using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Engineer")
        {
            Debug.Log("goal entered");
            collision.transform.GetComponent<Engineer>().colliders.Add("Goal");
            collision.transform.GetComponent<Engineer>().isAtGoal = true;
        }
        if (collision.tag == "Steam")
        {
            Debug.Log("goal entered");
            collision.transform.GetComponent<Steam>().colliders.Add("Goal");
            collision.transform.GetComponent<Steam>().isAtGoal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Engineer")
        {
            collision.transform.GetComponent<Engineer>().colliders.Remove("Goal");
            if (collision.transform.GetComponent<Engineer>().colliders.Contains("Goal"))
            {
                Debug.Log("goal exited");
                collision.transform.GetComponent<Engineer>().isAtGoal = false;
            }
        }
        if (collision.tag == "Steam")
        {
            collision.transform.GetComponent<Steam>().colliders.Remove("Goal");
            if (collision.transform.GetComponent<Steam>().colliders.Contains("Goal"))
            {
                Debug.Log("goal exited");
                collision.transform.GetComponent<Steam>().isAtGoal = false;
            }
        }
    }
}
