using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// comment

// koding unity -> c# -> c++
// koding unreal engine -> c++
// secara umum c++ termasuk salah satu bahasa tercepat

// role
// Designer 2d / 3d (ambil asset gratis di unity store)
// Sound Engineer (ambil sound gratis soundcloud / sound.org)
// Programmer (copy code dari tutorial)

public class test : MonoBehaviour
{
    int x = 10;
    string s = "Burung beo";
    bool flag = true;
    float f = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Halo dunia");
        // Debug.Log(s);
        // Debug.Log(flag);
        // Debug.Log("Test variable" + f + " adalah float");
        // Test variable 1.0 adalah float
        Debug.Log("HALO");

        // 1 - 10

        // int i => variable i sebagai integer
        // i <= 10 (selama masih <= 10 maka looping lanjut)
        // i++ (i + 1 setiap loop)

        // 1^2, 3^2, 5^2, 7^2
        for(int i = 1; i <= 10; i++){
            Debug.Log(i * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Halo dunia update");
    }
}
