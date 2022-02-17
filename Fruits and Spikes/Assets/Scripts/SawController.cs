using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public float maxX;
    public float minX;
    public bool movingRight;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement(){
        if (movingRight){
            if (transform.position.x >= maxX){
                movingRight = false;
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else {
            if (transform.position.x <= minX){
                movingRight = true;
            }
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
