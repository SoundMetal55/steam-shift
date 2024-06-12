using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Engineer : MonoBehaviour
{
    public Engineer engineer;
    public GameObject go;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public List<string> colliders = new List<string>();

    [Header("PipePlacement")]
    public GameObject pipe;
    public int numPipes;
    public GameObject vent;
    public int numVents;

    [Header("Movement X")]
    public float speed;
    float horizontal;

    [Header("Movement Y")]
    public float jumpForce;
    float vertical;

    [Header("Player Status")]
    public bool isAtGoal;
    public bool isClimbing;
    public bool isGliding;
    public bool isGrounded = false;
    public bool canJump = false;
    public bool isJumping = false;
    public Collider2D floorCollider;
    public ContactFilter2D floorFilter;
    public bool isInteracting;

    // Start is called before the first frame update
    void Start()
    {
        go = engineer.GetComponent<GameObject>();
        rb = engineer.GetComponent<Rigidbody2D>();
        sr = engineer.GetComponent<SpriteRenderer>();
        speed = 3f;
        jumpForce = 6.5f;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs();
        SetMovementStatus();
    }
    
    void FixedUpdate()
    {
        MovePlayer();

        if (Input.GetKey(KeyCode.Q))
        {
            CreatePipe(Mathf.Floor(rb.transform.position.x)+0.5f,Mathf.Floor(rb.transform.position.y)+0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliders.Add(collision.tag);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision.tag);
    }


    void MovePlayer()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            if (Input.GetKey(KeyCode.S) == true)
            {
                rb.velocity = new Vector2(horizontal * speed, vertical * speed);
            }
            else
            {
                rb.velocity = new Vector2(horizontal * speed, Mathf.Clamp(vertical * speed, 0f, vertical * speed));
            }
        }
        else if (isGliding)
        {
            rb.velocity = new Vector2(horizontal * speed * 0.5f, Mathf.Clamp(rb.velocity.y, -0.2f, 99f));
        }
        else
        {
            rb.gravityScale = 1f;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (canJump && vertical == 1f)
            {
                canJump = false;
                isJumping = true;
                Vector3 vel = rb.velocity;
                vel.y = 0;
                rb.velocity = vel;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isInteracting = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isClimbing)
            {
                rb.velocity = new Vector2(horizontal * speed * 0.5f, Mathf.Clamp(rb.velocity.y, -jumpForce, jumpForce/2));
                isGliding = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isGliding = false;
        }
    }

    void SetMovementStatus()
    {
        if (colliders.Contains("Ladder"))
        {
            isClimbing = true;
            isGliding = false;
        }
        else
        {
            isClimbing = false;
        }

        isGrounded = floorCollider.IsTouching(floorFilter);
        if (isGrounded && rb.velocity.y <= 0)
        {
            canJump = true;
            isJumping = false;
        }
    }

    public bool CreatePipe(float x, float y)
    {
        bool pipePlaced = false;

        if (numPipes > 0)
        {
            RaycastHit2D[] tiles;
            LayerMask mask = LayerMask.GetMask("PipePlaceable");
            //Debug.Log(mask.ToString());
            tiles = Physics2D.CircleCastAll(new Vector2(x, y), 0.5f, new Vector2(0f, 0f), 0.5f, mask);

            foreach (RaycastHit2D tile in tiles)
            {
                Destroy(tile.transform.gameObject);
                //Debug.Log(((tile.transform.gameObject).layer).ToString());
                //Debug.Log(mask.value.ToString());
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
