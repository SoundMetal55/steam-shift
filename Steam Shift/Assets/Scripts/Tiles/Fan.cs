using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    // debatable whether ladders should also have a script to handle physics changes or if fans should be handled in the player scripts. this works for now but will be rafactored)
    public bool isOn;
    public GameObject fanEffect;
    public GameObject button;

    void Start()
    {
        isOn = false;
        fanEffect.SetActive(false);
    }

    void Update()
    {
        fanEffect.SetActive(isOn);
        isOn = button.GetComponent<PressableButton>().activating.Count != 0;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Engineer" && isOn)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 19.62f);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, rb.velocity.y, 3f));
            Debug.Log("floating");
        }
    }
}
