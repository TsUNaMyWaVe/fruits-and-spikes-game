using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D col;
    public float speed, fadSpeed;
    public float jumpingVelocity;
    private enum State {idle, running, jumping, falling, climbing, dying};
    private State state = State.idle;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask traps;
    private int cherries = 0;
    public GameObject score;
    public GameObject genControl;
    public AudioSource JumpSFX, CollectSFX, DieSFX;
    private CollectableController collectableController;
    // Start is called before the first frame update
    void Start()
    {
        state = State.falling;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.dying){
            FadeOut();
        }
        float hDirection = Input.GetAxis("Horizontal");
        float vDirection = Input.GetAxis("Vertical");
        if (hDirection > 0 && state != State.dying){
            rb.velocity = new Vector2(speed,rb.velocity.y);
            transform.localScale = new Vector2(1,1);
        }
        else if (hDirection < 0 && state != State.dying){
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            transform.localScale = new Vector2(-1,1);
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && (col.IsTouchingLayers(ground) || col.IsTouchingLayers(traps) || state == State.climbing) && state != State.dying){
            JumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingVelocity);
            state = State.jumping;
        }
        if (vDirection > 0 && state == State.climbing && state != State.dying){
            rb.velocity = new Vector2(0, speed);
        }
        else if (vDirection < 0 && state == State.climbing && state != State.dying){
            rb.velocity = new Vector2(0, -speed);
        }
        VelocityState();
        anim.SetInteger("State", (int)state);
    }
    private void VelocityState(){
        if (state == State.dying){
            return;
        }
        if (state == State.jumping){
            if (rb.velocity.y < .1f){
                state = State.falling;
            }
        }
        else if (state == State.falling){
            if (col.IsTouchingLayers(ground)){
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 0.5f){
            state = State.running;
        }
        else if (state == State.climbing){
            return;
        }
        else {
            state = State.idle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Collectable"){
            CollectSFX.Play();
            collectableController = collision.gameObject.GetComponent<CollectableController>();
            if (collectableController != null)
                collectableController.Collected = true;
            genControl.GetComponent<GeneralControls>().Collect(collision.gameObject);
            cherries += 1;
            score.GetComponent<TMPro.TextMeshProUGUI>().text = "Fruits: " + cherries.ToString();
        }
        if (collision.tag == "Danger"){
            if (collision.GetType() == typeof(BoxCollider2D)){
                DieSFX.Play();
                genControl.GetComponent<GeneralControls>().Reset();
                state = State.dying;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            else if (collision.GetType() == typeof(CapsuleCollider2D)){
                state = State.climbing;
            }
        }
        if (collision.tag == "Rope"){
            state = State.climbing;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.tag == "Danger"){
            if (collision.GetType() == typeof(CapsuleCollider2D)){
                state = State.falling;
            }
        }
        if (collision.tag == "Rope" && state != State.dying){
            state = State.falling;
        }
    }

    private void FadeOut(){
        Color objectColor = GetComponent<Renderer>().material.color;
        float fadAmount = objectColor.a - (fadSpeed * Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadAmount);
        GetComponent<Renderer>().material.color = objectColor;
    }
    public int getScore(){
        return cherries;
    }

}
