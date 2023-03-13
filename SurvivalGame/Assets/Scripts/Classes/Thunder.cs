using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public int Damanaged {get; set;}

    public int CoolDown {get; set;}

    public int Level {get; set;}

    private Timer timer;

    public Thunder()
    {
        Damanaged = 30;
        CoolDown = 3;
        Level = 1;
    }

    public void Display()
    {
        Rigidbody2D rg2d = GetComponent<Rigidbody2D>();
        timer = GetComponent<Timer>();
        timer.Duration(0.1f);
        timer.run();
    }

    public void Update()
    {
        if (timer != null && !timer.isRunning())
        {
            Destroy(gameObject);
        }
    }

}
