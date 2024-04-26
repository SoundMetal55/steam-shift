using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineer : MonoBehaviour
{
    public Engineer engineer;
    public GameObject go;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public List<Collider2D> colliders = new List<Collider2D>();

    [Header("PipePlacement")]
    public GameObject pipe;
    public int numPipes;

    [Header("Movement X")]
    public float speed;
    float horizontal;

    [Header("Movement Y")]
    public float jumpForce;
    float vertical;
    public bool isClimbing;

    [Header("Movement Status")]
    public bool grounded = false;
    public bool jumping = false;
    public Collider2D floorCollider;
    public ContactFilter2D floorFilter;

    // Start is called before the first frame update
    void Start()
    {
        go = engineer.GetComponent<GameObject>();
        rb = engineer.GetComponent<Rigidbody2D>();
        sr = engineer.GetComponent<SpriteRenderer>();
        speed = 5f;
        jumpForce = 5f;
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
        SetJumpStatus();
    }
    
    void FixedUpdate()
    {
        MovePlayer();

        if (Input.GetKey(KeyCode.Q))
        {
            CreatePipe(Mathf.Floor(rb.transform.position.x)+0.5f,Mathf.Floor(rb.transform.position.y)+0.5f);
        }
    }

    void MovePlayer()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (!jumping && vertical == 1f)
            {
                jumping = true;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
        else
        {
            horizontal = 0f;
        }
        //vertical movement
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            vertical = 1f;
        }
        else
        {
            vertical = 0f;
        }
    }

    void SetJumpStatus()
    {
        grounded = floorCollider.IsTouching(floorFilter);
        if (grounded && rb.velocity.y <= 0)
        {
            jumping = false;
        }
    }

    public bool CreatePipe(float x, float y)
    {
        bool pipePlaced = false;

        if (numPipes > 0)
        {
            RaycastHit2D[] tiles;
            LayerMask mask = LayerMask.GetMask("SteamBarrier");
            Debug.Log(mask.ToString());
            tiles = Physics2D.CircleCastAll(new Vector2(x, y), 0.5f, new Vector2(0f, 0f), 0.5f, mask);

            foreach (RaycastHit2D tile in tiles)
            {
                Destroy(tile.transform.gameObject);
                Debug.Log(((tile.transform.gameObject).layer).ToString());
                Debug.Log(mask.value.ToString());
                pipePlaced = true;
            }

            if (pipePlaced)
            {
                Instantiate(pipe, new Vector2(x, y), Quaternion.identity);

                numPipes -= 1;
                return true;
            }

        }
        return false;
    }

    // could be useful for imlementing a better player inventory if we have lots of mechanics
    // https://www.youtube.com/watch?v=BO9E723Jiqs
}
