using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 recordedVelocity;
    bool isStoped = false;
    BoxCollider2D boxCollider2D;
    [SerializeField] float timeAffected;
    TimeManager timeManager;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        recordedVelocity = rb.velocity;
        // boxCollider2D = GetComponent<BoxCollider2D>();
        // boxCollider2D.enabled = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAffected -= Time.deltaTime;
        if(timeAffected < 0 && timeManager.timeIsStoped && isStoped == false){
            if(animator != null) animator.speed = 0;
            // boxCollider2D.enabled = true;
            recordedVelocity = rb.velocity;
            rb.velocity = Vector3.zero; // (0.1, 0.2, 0.3)
            rb.isKinematic = true;
            isStoped = true;
        }

    }

    public void ContinueTime(){
        if(animator != null) animator.speed = 1;
        // boxCollider2D.enabled = false;
        rb.velocity = recordedVelocity;
        rb.isKinematic = false;
        isStoped = false;
    }
}
