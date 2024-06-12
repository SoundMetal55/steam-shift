using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite end;
    public Sprite middle;
    public Sprite corner;
    public Sprite tri;
    public Sprite four;
    // Start is called before the first frame update
    void Start()
    {
        // too many calls but not enough time to fix this
        InvokeRepeating("ApplySprite", 0, 0.5f);
    }

    void ApplySprite()
    {
        
        bool[] tiles = new bool[4];
        RaycastHit2D[] upTile;
        RaycastHit2D[] rightTile;
        RaycastHit2D[] downTile;
        RaycastHit2D[] leftTile;
        LayerMask mask = LayerMask.GetMask("Pipe");
        upTile = Physics2D.CircleCastAll(new Vector2(this.transform.position.x, this.transform.position.y + 1f), 0.5f, new Vector2(0f, 0f), 0.1f, mask);
        rightTile = Physics2D.CircleCastAll(new Vector2(this.transform.position.x + 1f, this.transform.position.y), 0.5f, new Vector2(0f, 0f), 0.1f, mask);
        downTile = Physics2D.CircleCastAll(new Vector2(this.transform.position.x, this.transform.position.y - 1f), 0.5f, new Vector2(0f, 0f), 0.1f, mask);
        leftTile = Physics2D.CircleCastAll(new Vector2(this.transform.position.x - 1f, this.transform.position.y), 0.5f, new Vector2(0f, 0f), 0.1f, mask);

        int connections = 0;
        if (upTile.Length != 0) { connections += 1; tiles[0] = true; } else { tiles[0] = false; Debug.Log("1"); }
        if (rightTile.Length != 0) { connections += 1; tiles[1] = true; } else { tiles[1] = false; Debug.Log("1"); }
        if (downTile.Length != 0) { connections += 1; tiles[2] = true; } else { tiles[2] = false; Debug.Log("1"); }
        if (leftTile.Length != 0) { connections += 1; tiles[3] = true; } else { tiles[3] = false; Debug.Log("1"); }

        if (connections == 4)
        {
            //four
            spriteRenderer.sprite = four;
        }
        else if (connections == 3)
        {
            //tri
            spriteRenderer.sprite = tri;
            if (tiles[0] == false) { this.transform.rotation = Quaternion.Euler(0, 0, 0); }
            else if (tiles[1] == false) { this.transform.rotation = Quaternion.Euler(0, 0, -90); }
            else if (tiles[2] == false) { this.transform.rotation = Quaternion.Euler(0, 0, -180); }
            else if (tiles[3] == false) { this.transform.rotation = Quaternion.Euler(0, 0, -270); }
        }
        else if (connections == 2)
        {
            if ((tiles[0] == false && tiles[2] == false) || (tiles[1] == false && tiles[3] == false))
            {
                //middle
                spriteRenderer.sprite = middle;
                if (tiles[0] == false) { this.transform.rotation = Quaternion.Euler(0, 0, 0); }
                else { this.transform.rotation = Quaternion.Euler(0, 0, 90); }
            }
            else
            {
                //corner
                spriteRenderer.sprite = corner;
                if (tiles[0] == true && tiles[1] == true) { this.transform.rotation = Quaternion.Euler(0, 0, 0); }
                if (tiles[1] == true && tiles[2] == true) { this.transform.rotation = Quaternion.Euler(0, 0, -90); }
                if (tiles[2] == true && tiles[3] == true) { this.transform.rotation = Quaternion.Euler(0, 0, -180); }
                if (tiles[3] == true && tiles[0] == true) { this.transform.rotation = Quaternion.Euler(0, 0, -270); }
            }
        }
        else
        {
            //end
            spriteRenderer.sprite = end;
            if (tiles[0] == true) { this.transform.rotation = Quaternion.Euler(0, 0, 270); }
            if (tiles[1] == true) { this.transform.rotation = Quaternion.Euler(0, 0, 180); }
            if (tiles[2] == true) { this.transform.rotation = Quaternion.Euler(0, 0, 90); }
            if (tiles[3] == true) { this.transform.rotation = Quaternion.Euler(0, 0, 0); }
        }
    }
}
