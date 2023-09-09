using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopController : MonoBehaviour
{
    TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            timeManager.StopTime();
        }
        if(Input.GetKeyDown(KeyCode.E)){
            timeManager.ContinueTime();
        }
    }
}
