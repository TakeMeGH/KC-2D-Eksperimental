using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerSpawner : MonoBehaviour
{
    [SerializeField] GameObject dagger;
    BoxCollider2D boxCollider2D;
    [SerializeField] Camera cam;
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkFacing();
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            spawnDagger();
        }
    }

    void spawnDagger(){
        GameObject spawnedDagger = Instantiate(dagger, boxCollider2D.bounds.center, Quaternion.Euler(0, 0, angle - 90));
        spawnedDagger.GetComponent<DaggerController>().angle = angle;
        // kita ke kiri -> scale dari x minus
        // kita ke kanan -> scale dari x plus

        // if(transform.localScale.x < 0){
        //     spawnedDagger.GetComponent<DaggerController>().facing = -1;
        // }
        // else{
        //     spawnedDagger.GetComponent<DaggerController>().facing = 1;
        // }
    }

    void checkFacing(){
        Vector3 mousePoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gunPoint = (mousePoint - boxCollider2D.bounds.center).normalized;
        angle = Mathf.Atan2(gunPoint.y, gunPoint.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
    }
}
