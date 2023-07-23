using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] KeyCode rightButton;
    [SerializeField] KeyCode leftButton;
    Vector2 baseSpeed = new Vector2(2, 0);
    [SerializeField] float jumpSpeed;
    [SerializeField] float moveSpeed;
    Animator animator;
    bool isGrounded;

    // berapa lama spacebar di hold
    float curTime;
    bool isSliding;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // loncat kecepatan 2
    // kanan ->
    // Update is called once per frame
    void Update()
    {

        // unity new input system
        if(Input.GetKey(rightButton)){
            rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);
        }
        else if(Input.GetKey(leftButton)){
            rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(isGrounded == true && Input.GetKey(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        
        if(isSliding){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 0.05f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = true;
        }
        if(other.gameObject.tag == "Sliding"){
            isSliding = true;
            animator.Play("SlidingAnimation");
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = false;
        }
        if(other.gameObject.tag == "Sliding"){
            isSliding = false;
            animator.Play("IdleAnimation");

        }
    }
}      
