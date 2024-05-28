using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject entrance;
    public GameObject exit;

    public bool isAutomatic;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (entrance.GetComponent<PressableButton>().activating.Contains("Engineer"))
        {
            collision.transform.position = exit.transform.position;
        }
        if (entrance.GetComponent<PressableButton>().activating.Contains("Steam"))
        {
            collision.transform.position = exit.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAutomatic)
        {
            if (collision.tag == "Engineer")
            {
                collision.transform.position = exit.transform.position;
            }
            if (collision.tag == "Steam")
            {
                collision.transform.position = exit.transform.position;
            }
        }
    }
}
