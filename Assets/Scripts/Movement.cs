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
    Vector3 originalTransformScale;
    BoxCollider2D boxCollider2D;
    [SerializeField] LayerMask testLayermask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalTransformScale = transform.localScale;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // loncat kecepatan 2
    // kanan ->
    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.gravityScale);
        if(isSliding){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 0.05f);
        }
        else if(isSliding == false){
            if(Input.GetKey(rightButton)){
                animator.Play("walkingAnimation");
                transform.localScale = new Vector2(originalTransformScale.x, transform.localScale.y);
                rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);
            }
            else if(Input.GetKey(leftButton)){
                animator.Play("walkingAnimation");
                transform.localScale = new Vector2(-originalTransformScale.x, transform.localScale.y);
                rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
            }
            else{
                animator.Play("IdleAnimation");
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if(isGrounded == true && Input.GetKey(KeyCode.Space)){
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }

        checkSliding();
    }

    void checkSliding(){
        // 3.14, 2.5, 10.7 decimal - 1/2 pecahan

        // basis 10 (decimal) -> 0,1,2,3,4,5,6,7,8,9 -> jari kita 10
        // basis 16 (hexadecimal) -> 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, a, b, c, d, e, f
        
        // 10 -> decimal (angka setelah 9) -> nilainya sepuluh
        // 10 -> hexadecimal (angka setelah f) -> nilainya tujuh belas

        // basis 2 (biner/binary) -> 0, 1
        // 10 -> disimpan sebagai 1010


        // 1  000 1   1   0 -> decimal -> 2^6 + 2^2 + 2^1 = 64 + 4 + 1 = 69
        // 2^6    2^2 2^1 2^0  

        // biner 1 -> 1 (2^0 * 1)
        // biner 10 -> 2 (2^1 * 1 + 2^0 * 0)
        // biner 11 -> 3 (2^1 * 1 + 2^0 * 1)

        // biner 101 -> (2^2 * 1 + 2^0 * 1) -> 5

        // 10 -> decimal nilainya sepuluh, dalam biner nilainya dua

        // 2^3 + 2^1 -> 1    0    1   0
        //              2^3  2^2  2^1 2^0

        // biner dari decimal 11 -> 2^3 + 2^1 + 2^0
        // 11 - 8 = 3
        // 1011 -> bener :D

        // decimal 34 -> (10^1 * 3 + 10^0 * 4)
        
        // << (shift left)
        // >> (shift right)

        // 1 << 6
        // 1
        // 1000000

        // 2 << 6
        // 10 biner dari 2 = 10
        // 10000000

        // 0 << 6
        // 0
        // 0000000

        // x << y

        // x << y

        // 1 + 5 = 6

        // 2
        LayerMask layerMask = 1 << 6;
        float distance = 1;
        Vector2 direction = new Vector2(transform.localScale.x, 0);
        // boxCollider2D.bounds.center, new Vector2(1, 0), 1.0f, layerMask
        // boxCollider2D.bounds.center titik awalnya (origin)
        // new Vector2(1, 0) - direction
        // 1.0f distance
        if(Physics2D.Raycast(boxCollider2D.bounds.center, direction, distance, layerMask)){
            Debug.DrawRay(boxCollider2D.bounds.center, direction * distance, Color.green);
            if(isSliding == false) animator.Play("SlidingAnimation");
            isSliding = true;

        }
        else{
            Debug.DrawRay(boxCollider2D.bounds.center, direction * distance, Color.yellow);
            isSliding = false;

        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = true;
        }
        // if(other.gameObject.tag == "Sliding"){
        //     isSliding = true;
        //     animator.Play("SlidingAnimation");
        // }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = false;
        }
        // if(other.gameObject.tag == "Sliding"){
        //     isSliding = false;
        //     animator.Play("IdleAnimation");
        // }
    }
}      
