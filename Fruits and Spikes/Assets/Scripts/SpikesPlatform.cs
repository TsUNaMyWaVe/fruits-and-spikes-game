using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikesPlatform : MonoBehaviour
{
    public GameObject platform;
    public float jumpingHeight = 10;
    private Rigidbody2D rb;
    private bool jumped = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = platform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player" && !jumped){
            rb.velocity = new Vector2(rb.velocity.x, jumpingHeight);
            jumped = true;
        }
    }
}
