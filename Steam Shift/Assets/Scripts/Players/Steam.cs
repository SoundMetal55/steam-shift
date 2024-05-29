using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour
{
    public Steam steam;
    public GameObject go;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public List<string> colliders = new List<string>();

    [Header("Suit")]
    public bool canToggle;
    public GameObject suit;
    public GameObject vent;

    [Header("Movement X")]
    public float speed;
    float horizontal;

    [Header("Movement Y")]
    float vertical;
    public bool isClimbing;

    [Header("Player Status")]
    public bool isAtGoal;
    public bool isSuit;
    public bool isInteracting;

    // Start is called before the first frame update
    void Start()
    {
        //go = steam.GetComponent<GameObject>();
        rb = steam.GetComponent<Rigidbody2D>();
        sr = steam.GetComponent<SpriteRenderer>();
        speed = 3f;
        isSuit = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs();

        if (!canToggle)
        {
            SetToggleStatus();
        }

        
    }

    void FixedUpdate()
    {
        MovePlayer();

        if (isInteracting && (canToggle || true))
        {
            ToggleSuit();
        }

        isClimbing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliders.Add(collision.tag);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision.tag);
    }

    void SetToggleStatus()
    {
        Debug.Log(canToggle);
        if (colliders.Contains("Vent") == false && colliders.Contains("Suit") == false)
        {
            canToggle = true;
        }
    }

    void ToggleSuit()
    {
        canToggle = false;
        if (!isSuit)
        {
            RaycastHit2D[] tiles;
            LayerMask mask = LayerMask.GetMask("Suit");
            tiles = Physics2D.CircleCastAll(new Vector2(Mathf.Floor(rb.transform.position.x) + 0.4f, Mathf.Floor(rb.transform.position.y) + 0.4f), 0.5f, new Vector2(0f, 0f), 0.5f, mask);

            if (colliders.Contains("Suit") && tiles != null)
            {
                foreach (RaycastHit2D tile in tiles)
                {
                    go.transform.position = tile.transform.position;
                    Instantiate(vent, tile.transform.position, tile.transform.rotation);
                    Destroy(tile.transform.gameObject);
                }

                go.layer = LayerMask.NameToLayer("Engineer");
                isSuit = true;
                go.transform.localScale = new Vector2(0.8f, 1.6f);
                isInteracting = false;
            }
        }
        else
        {
            RaycastHit2D[] tiles;
            LayerMask mask = LayerMask.GetMask("Vent");
            tiles = Physics2D.CircleCastAll(new Vector2(Mathf.Floor(rb.transform.position.x) + 0.4f, Mathf.Floor(rb.transform.position.y) + 0.4f), 0.5f, new Vector2(0f, 0f), 0.5f, mask);

            if (colliders.Contains("Vent") && tiles != null)
            {
                foreach (RaycastHit2D tile in tiles)
                {
                    go.transform.position = tile.transform.position;
                    Instantiate(suit, tile.transform.position, tile.transform.rotation);
                    Destroy(tile.transform.gameObject);
                }

                go.layer = LayerMask.NameToLayer("Steam");
                isSuit = false;
                go.transform.localScale = new Vector2(0.8f, 0.8f);
                isInteracting = false;
            }
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
        
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            isInteracting = true;
        }
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            isInteracting = false;
        }
    }
}