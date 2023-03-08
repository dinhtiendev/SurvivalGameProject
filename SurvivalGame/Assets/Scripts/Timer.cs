using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float elapsedTime = 0;
    bool running;
    float durations = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void Duration(float duration)
    {
        durations = duration;
    }

    public float getDu()
    {
       
        return durations;
    }
    public void run()
    {
        running = true;
    }
    public bool isRunning()
    {
        return running;
    }
    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= durations)
            {
                elapsedTime = 0;
                running = false;
            }
        }
      
    }

}
