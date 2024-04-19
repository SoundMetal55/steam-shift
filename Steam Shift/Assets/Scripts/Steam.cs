using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour
{
    public Steam steam;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    [Header("Movement")]
    public float speed;
    float horizontal;
    float vertical;

    [Header("Movement Status")]
    public ContactFilter2D steamFilter;

    // Start is called before the first frame update
    void Start()
    {
        rb = steam.GetComponent<Rigidbody2D>();
        spriteRenderer = steam.GetComponent<SpriteRenderer>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //if ()
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        FlipSprite();
    }

    void FlipSprite()
    {
        if (horizontal < 0f)
        {
            spriteRenderer.flipX = false;
        }
        if (horizontal > 0f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void GetPlayerInputs()
    {
        // horizontal movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }
        else
        {
            horizontal = 0f;
        }
        //vertical movement
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;
        }
        else
        {
            vertical = 0f;
        }
    }
}
