using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int Damanaged {get; set;}
    public int CoolDown {get; set;}
    public int TimeBack {get; set;}
    public float Speed {get; set;}
    public int Level {get; set;}

    Timer timer;
    Rigidbody2D rg2d;

    void Update()
    {
        if (!timer.isRunning())
        {
            rg2d.velocity = new Vector2(0, 0);
            transform.position = Vector2.MoveTowards(transform.position, Manager.instance.player.transform.position, Time.deltaTime * Speed);
            transform.up = -transform.position;
            if (transform.position == Manager.instance.player.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }

    public Hammer()
    {
        Damanaged = 25 * 2;
        CoolDown = 5;
        TimeBack = 2;
        Speed = 10;
        Level = 1;
    }

    public void Move()
    {
        timer = GetComponent<Timer>();
        rg2d = GetComponent<Rigidbody2D>();
        timer.Duration(TimeBack);
        timer.run();
        rg2d.velocity = new Vector2(Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad), Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad)) * Speed;
        transform.up = transform.position;
    }
}
