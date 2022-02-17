using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private bool isPressed = false;
    private Animator anim;
    private Collider2D col;
    public GameObject activatedObj;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        activatedObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision){
        isPressed = true;
        anim.SetBool("Pressed", isPressed);
        activatedObj.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision){
        isPressed = false;
        anim.SetBool("Pressed", isPressed);
        activatedObj.SetActive(false);
    }
}
