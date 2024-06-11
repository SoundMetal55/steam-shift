using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableButton : MonoBehaviour
{
    public bool isButton;

    public bool isPressurePlate;

    private bool steamColliding;
    private bool engineerColliding;
    private bool boxColliding;

    public bool steamActivatable;
    public bool engineerActivatable;
    public bool boxActivatable;

    public List<string> activating = new List<string>();

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isButton || isPressurePlate)
        {
            if (collision.tag == "Engineer" && engineerActivatable)
            {
                engineerColliding = true;
                if ((collision.GetComponent<Engineer>().isInteracting || isPressurePlate) && !activating.Contains("Engineer"))
                {
                    activating.Add(collision.tag);
                }
                else if (!collision.GetComponent<Engineer>().isInteracting && !isPressurePlate)
                {
                    activating.Remove(collision.tag);
                }
            }
            if (collision.tag == "Steam" && steamActivatable)
            {
                steamColliding = true;
                if ((collision.GetComponent<Steam>().isInteracting || isPressurePlate) && !activating.Contains("Steam"))
                {
                    activating.Add(collision.tag);
                }
                else if (!collision.GetComponent<Steam>().isInteracting && !isPressurePlate)
                {
                    activating.Remove(collision.tag);
                }
            }
            if (collision.tag == "Box" && boxActivatable)
            {
                boxColliding = true;
                if (!activating.Contains("Box"))
                {
                    activating.Add(collision.tag);
                }
            }
        }
        
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (isButton || isPressurePlate)
        {
            if (collision.tag == "Engineer")
            {
                engineerColliding = false;
                activating.Remove(collision.tag);
            }
            if (collision.tag == "Steam")
            {
                steamColliding = false;
                activating.Remove(collision.tag);
            }
            if (collision.tag == "Box")
            {
                boxColliding = false;
                activating.Remove(collision.tag);
            }
        }
    }
}
