using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineer : MonoBehaviour
{
    public Engineer engineer;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public GameObject pipe;

    [Header("Movement X")]
    public float speed;
    float horizontal;

    [Header("Movement Y")]
    public float jumpForce;
    float vertical;

    [Header("Movement Status")]
    public bool grounded = false;
    public bool jumping = false;
    public Collider2D floorCollider;
    public ContactFilter2D floorFilter;

    // Start is called before the first frame update
    void Start()
    {
        rb = engineer.GetComponent<Rigidbody2D>();
        spriteRenderer = engineer.GetComponent<SpriteRenderer>();
        speed = 5f;
        jumpForce = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs();
        SetPlayerStatus();
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
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!jumping && vertical == 1f)
        {
            jumping = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //rb.AddForce(new Vector2(0f, vertical * verticalSpeed));
        //rb.AddForce(new Vector2(horizontal * horizontalSpeed, 0f));
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

    void SetPlayerStatus()
    {
        grounded = floorCollider.IsTouching(floorFilter);
        if (grounded && rb.velocity.y <= 0)
        {
            jumping = false;
        }
    }

    /*
    float maxDist = 0.5;
    GameObject[] tiles;
    GameObject itemToDestroy;
        bool PlacePipe()
        {
            items = GameObject.FindGameObjectsWithTag("item");
            curDist = 5;

            foreach (GameObject item in items)
            {
                float dist = Vector3.Distance(transform.position, item.transform.position);
                if (dist > curDist)
                {
                    curDist = dist;
                    itemToDestroy = item;
                }
            }
            if (itemToDestroy != null)
            {
                Destroy(itemToDestroy);
            }
        }
    */
    
    public void CreatePipe(float x, float y)
    {
        Instantiate(pipe, new Vector2(x, y), Quaternion.identity);

        RaycastHit2D[] tiles;
        LayerMask mask = LayerMask.GetMask("SteamBarrier");
        Debug.Log(mask.ToString());
        tiles = Physics2D.CircleCastAll(new Vector2(x, y), 0.5f, new Vector2(0f, 0f), 0.5f, mask);

        foreach (RaycastHit2D tile in tiles)
        {
            Destroy(tile.transform.gameObject);
            Debug.Log(((tile.transform.gameObject).layer).ToString());
            Debug.Log(mask.value.ToString());
        }

        /*
        RaycastHit2D[] tiles;
        LayerMask mask = LayerMask.GetMask("Pipe");
        tiles = Physics2D.CircleCastAll(new Vector2(x, y), 10f, new Vector2(0f, 0f), 10f, mask);

        foreach (RaycastHit2D tile in tiles)
        {
            Destroy(tile.transform.gameObject);
            Debug.Log(((tile.transform.gameObject).layer).ToString());
            Debug.Log(mask.value.ToString());
        }

        
        Debug.Log(x); Debug.Log(y);
        //Ray ray = (new Vector3(x, y, -1f), new Vector3(x, y, 0f));
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(x, y, -1f), new Vector3(x, y, -2f), out hit, 2f))
        {
            //RaycastHit hit = Physics.Raycast(new Vector3(x, y, -1f), new Vector3(x, y, 0f), 2f);
            Destroy(hit.transform.gameObject); // destroy the object hit
        }
        */
    }

}
