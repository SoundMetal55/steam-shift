using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableLever : MonoBehaviour
{
    public bool isLever;

    private bool steamColliding;
    private bool engineerColliding;

    public bool steamActivatable;
    public bool engineerActivatable;

    public List<string> activating = new List<string>();

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isLever)
        {
            if (collision.tag == "Engineer" && engineerActivatable)
            {
                engineerColliding = true;
                if (collision.GetComponent<Engineer>().isInteracting && !activating.Contains("Engineer"))
                {
                    activating.Add(collision.tag);
                    collision.GetComponent<Engineer>().isInteracting = false;
                }
                if (collision.GetComponent<Engineer>().isInteracting && activating.Contains("Engineer"))
                {
                    activating.Clear();
                    collision.GetComponent<Engineer>().isInteracting = false;
                }
            }
            if (collision.tag == "Steam" && steamActivatable)
            {
                steamColliding = true;
                if (collision.GetComponent<Steam>().isInteracting && !activating.Contains("Steam"))
                {
                    activating.Add(collision.tag);
                    collision.GetComponent<Steam>().isInteracting = false;
                }
                if (collision.GetComponent<Steam>().isInteracting && activating.Contains("Steam"))
                {
                    activating.Clear();
                    collision.GetComponent<Steam>().isInteracting = false;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (isLever)
        {
            if (collision.tag == "Engineer")
            {
                engineerColliding = false;
            }
            if (collision.tag == "Steam")
            {
                steamColliding = false;
            }
        }
    }
}
