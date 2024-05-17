using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject button;
    public GameObject pointOne;
    public GameObject pointTwo;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (button.GetComponent<PressableButton>().activating.Count != 0)
        {
            collision.transform.position = new Vector3(pointOne.transform.position.x, pointOne.transform.position.y, 2f);
            collision.transform.position = new Vector3(pointTwo.transform.position.x, pointTwo.transform.position.y, 2f);
        }
    }
}
