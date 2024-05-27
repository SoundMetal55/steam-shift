using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject entrance;
    public GameObject exit;

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
}
