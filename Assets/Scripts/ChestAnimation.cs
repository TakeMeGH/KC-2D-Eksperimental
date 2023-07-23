using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    Animator animator;
    bool isChestClosed = true;
    bool isClosed = false;
    [SerializeField] GameObject inventory;
    // public bool openChestInteraction;
    // public bool closeChestInteraction;
    // float idleTime;
    
    
    // public List<string> idleAnimation;
    // public List<string> runningAnimation;
    // uniqueIdle1, uniqueIdle2, uniqueIdle3, uniqueIdle4
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // idleTime += Time.deltaTime;
        // if(idleTime >= 120){
        //     int randomIdleAnimationIdx = Random.Range(0, idleAnimation.Count);

        //     // animator.Play("uniqueIdle1");

        //     animator.Play(idleAnimation[randomIdleAnimationIdx]);


        //     // -> after beberapa waktu

        //     animator.Play(runningAnimation[randomIdleAnimationIdx]);
        // }

    //    if(openChestInteraction == true){
    //         openChestInteraction = false;
    //         openChest();
    //    }
    //    else if(closeChestInteraction == true){
    //         closeChestInteraction = false;
    //         closeChest();
    //    }

        // if(Input.GetKey(KeyCode.F)){
        //     Debug.Log("input masuk");
        // }

        chestMechanism();
    }

    void chestMechanism(){
        if(Input.GetKeyDown(KeyCode.F) && isClosed){
            if(isChestClosed == true){
                isChestClosed = false;
                openChest();
                inventory.SetActive(true);
            }
            else{
                isChestClosed = true;
                closeChest();
                inventory.SetActive(false);

            }
        }
    }
    public void openChest(){
        // openChestInteraction = false;
        animator.Play("OpenChest");
        // animator.SetTrigger("OpenTrigger");
    }

    public void closeChest(){
        // closeChestInteraction = false;
        animator.Play("CloseChest");
        // animator.SetTrigger("CloseTrigger");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isClosed = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        isClosed = false;
    }

    // private void OnTriggerEnter(Collider other) { // sekali
        
    // }

    // private void OnTriggerStay(Collider other) { // terus menerus
        
    // }

    // private void OnTriggerExit(Collider other) { // sekali
        
    // }
}
