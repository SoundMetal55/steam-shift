using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit2D[] tiles;
        LayerMask mask = LayerMask.GetMask("SteamBarrier");
        Debug.Log(mask.ToString());
        tiles = Physics2D.CircleCastAll(transform.position, 10f, new Vector2(0f, 0f), 10f, mask);

        foreach (RaycastHit2D tile in tiles)
        {
            Destroy(tile.transform.gameObject);
            Debug.Log(((tile.transform.gameObject).layer).ToString());
            Debug.Log(mask.value.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
