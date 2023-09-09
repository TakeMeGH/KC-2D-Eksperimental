using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;


// satu object
// mengatur kondisi time sekarang -> time stop / time continue
public class TimeManager : MonoBehaviour
{

    public bool timeIsStoped = false;
    public void ContinueTime(){
        timeIsStoped = false;

        var objs = FindObjectsOfType<TimeBody>();
        for(int i = 0; i < objs.Length; i++){
            objs[i].GetComponent<TimeBody>().ContinueTime();
        }
    }

    public void StopTime(){
        timeIsStoped = true;
    }
}
