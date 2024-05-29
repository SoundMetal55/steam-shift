using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermeableFloor : MonoBehaviour
{
    public Collider2D col;
    public bool onFloor;

    public void setPlatform(Collision2D other, bool val)
    {
        var player = (other.gameObject.GetComponent<Engineer>() || other.gameObject.GetComponent<Steam>());
        if (player != null)
        {
            onFloor = val;
        }
    }
    
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (onFloor && Input.GetKey(KeyCode.S))
        {
            col.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        col.enabled = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        setPlatform(other, true);
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        setPlatform(other, true);
    }
}
