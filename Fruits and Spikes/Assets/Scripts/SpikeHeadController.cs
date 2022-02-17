using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadController : MonoBehaviour
{
    public bool movingRight = true;
    public float speed = 5f;
    public float maxDistance = 10f;
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement(){
        if (movingRight){
            if (transform.position.x >= pos.x + maxDistance){
                movingRight = false;
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else {
            if (transform.position.x <= pos.x - maxDistance){
                movingRight = true;
            }
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
