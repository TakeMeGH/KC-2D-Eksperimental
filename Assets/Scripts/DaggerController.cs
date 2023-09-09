using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : MonoBehaviour
{
    float destroyTime = 2f;
    float speed = 10f;
    public int facing = 1;
    Rigidbody2D rb;
    Vector3 dir;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        dir = transform.right;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * speed;

    }

    // Update is called once per frame
    void Update()
    {
        // destroyTime -= Time.deltaTime;
        // if(destroyTime <= 0){
        //     Destroy(gameObject);
        // }
    }

}
