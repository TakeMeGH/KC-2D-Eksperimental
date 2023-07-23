using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseValue : MonoBehaviour
{
    [SerializeField] VariableValue val; // private
    [SerializeField] int value;
    // Start is called before the first frame update
    void Start()
    {

        // +, -, *, /, % (modulo)
        // 10 / 3 = 3 sisa 1
        // 10 / 3 -> 3 * 3 = 9

        // 10 % 3 = 1

        // 27 % 5 = 2
        // 5 * 5 = 25


        // if(bool){
            // masuk true
        // }

        // 5 > 3 hasilnya bool true
        // 3 > 5 hasilnya bool false

        // = assign value (masukin nilai variable)
        // == perbandingan nilai hasilnya bool

        // 5 % 3 == 0 false
        

        // value % 3 == 0 artinya value bilangan kelipatan 3
        if(value % 3 == 0){
            // yang masuk hanya kelipatan 3
            Debug.Log("kelipatan 3");
        }

        
        if(value % 5 == 0){
            // yang masuk hanya kelipatan 5
            Debug.Log("kelipatan 5");
        }
        else if(value % 7 == 0){
            Debug.Log("kelipatan 7");

        }
        // else{
        //     // bukan kelipatan 3 atau 5
        //     Debug.Log("bukan kelipatan 3 atau 5");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
