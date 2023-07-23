using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestFunction(1);
    }

    string TestFunction(int x){
        Debug.Log("test function dipanggil");
        return "halo";
    }
    // f(x) = x^2 + x + 1
    // f(1) = 3 -> return

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
         Debug.Log("Collide " + other.gameObject.tag);
    }

    void OnCollisionExit2D(Collision2D other) {
        
    }

    void OnCollisionStay2D(Collision2D other) {
        
    }
}
