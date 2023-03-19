using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float elapsedTime = 0;
    bool running;
    int count;
    float durations = 0;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }
    public void Duration(float duration)
    {
        durations = duration;
    }
    public int getCount()
    {

        return count;
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
            count = (int)(durations - elapsedTime);
            if (elapsedTime >= durations)
            {
                
                elapsedTime = 0;
                running = false;
            }
        }
      
    }

}
