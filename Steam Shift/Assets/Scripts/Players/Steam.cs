using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour
{
    public Steam steam;
    public GameObject go;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public List<Collider2D> colliders = new List<Collider2D>();

    [Header("Movement X")]
    public float speed;
    float horizontal;

    [Header("Movement Y")]
    float vertical;
    public bool isClimbing;

    [Header("Mode Status")]
    public bool isSuit;

    // Start is called before the first frame update
    void Start()
    {
        //go = steam.GetComponent<GameObject>();
        rb = steam.GetComponent<Rigidbody2D>();
        sr = steam.GetComponent<SpriteRenderer>();
        speed = 5f;
        isSuit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliders.Add(collision);
        if (collision.tag == "Ladder")
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision);
        if (collision.tag == "Ladder")
        {
            if (colliders.Contains(collision))
            {
                isClimbing = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs();
    }

    void FixedUpdate()
    {
        MovePlayer();

        if (Input.GetKey(KeyCode.RightControl))
        {
            ToggleSuitOn();
        }
        if (Input.GetKey(KeyCode.RightAlt))
        {
            ToggleSuitOff();
        }

        isClimbing = false;
    }

    void ToggleSuitOn()
    {
        if (true)
        {
            go.layer = LayerMask.NameToLayer("Engineer");
            isSuit = true;
            go.transform.localScale = new Vector2(0.8f, 1.6f);
        }
    }

    void ToggleSuitOff()
    {
        if (true)
        {
            go.layer = LayerMask.NameToLayer("Steam");
            isSuit = false;
            go.transform.localScale = new Vector2(0.8f, 0.8f);
        }
    }

    void MovePlayer()
    {
        if (!isSuit)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        else
        {
            if (isClimbing && !isClimbing) //disable climb for now
            {
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(horizontal * speed, vertical * speed);
            }
            else
            {
                rb.gravityScale = 1f;
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
        }
        FlipSprite();
    }

    void FlipSprite()
    {
        if (horizontal < 0f)
        {
            sr.flipX = false;
        }
        if (horizontal > 0f)
        {
            sr.flipX = true;
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