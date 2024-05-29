using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentVelocity : MonoBehaviour
{
    public GameObject newParent;
    public GameObject originalParent;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Engineer")
        {
            Debug.Log("Enter velocity");
            originalParent = collision.gameObject.transform.parent.gameObject;
            collision.gameObject.transform.parent = newParent.transform;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Engineer")
        {
            Debug.Log("Exit velocity");
            collision.gameObject.transform.parent = originalParent.transform;
        }
    }
}
