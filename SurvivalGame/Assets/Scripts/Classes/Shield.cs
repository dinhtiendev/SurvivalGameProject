using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int CoolDown {get; set;}
    public float TimeActive {get; set;}
    public int Level {get; set;}

    private Timer timer;

    public Shield()
    {
        CoolDown = 5;
        TimeActive = 3;
        Level = 1;
    }

    public void Display()
    {
        Rigidbody2D rg2d = GetComponent<Rigidbody2D>();
        Player player = Manager.instance.player;
        PolygonCollider2D collider = player.GetComponent<PolygonCollider2D>();
        collider.isTrigger = true;

        timer = GetComponent<Timer>();
        timer.Duration(TimeActive);
        timer.run();

    }
    public void Update()
    {
        Player p = Manager.instance.player;
        transform.position = p.transform.position;
        if (timer != null && !timer.isRunning())
        {
            Destroy(gameObject);
            PolygonCollider2D collider = p.GetComponent<PolygonCollider2D>();
            collider.isTrigger = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject[] monster = GameObject.FindGameObjectsWithTag("tanker");
        GameObject[] monster2 = GameObject.FindGameObjectsWithTag("flasher");
        GameObject[] monster3 = GameObject.FindGameObjectsWithTag("monster");
        for (int i = 0; i < monster.Length; i++ )
        {
            Rigidbody2D r = monster[i].gameObject.GetComponent<Rigidbody2D>();
            r.velocity= Vector3.zero;
        }
        for (int i = 0; i < monster2.Length; i++)
        {
            Rigidbody2D r = monster2[i].gameObject.GetComponent<Rigidbody2D>();
            r.velocity = Vector3.zero;
        }
    
        for (int i = 0; i < monster3.Length; i++)
        {
            Rigidbody2D r = monster3[i].gameObject.GetComponent<Rigidbody2D>();
            r.velocity = Vector3.zero;
        }
    
    }
}
