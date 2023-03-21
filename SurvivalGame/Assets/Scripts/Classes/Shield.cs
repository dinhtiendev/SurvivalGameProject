using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int CoolDown {get; set;}
    public float TimeActive {get; set;}
    public int Level {get; set;}

    private Timer timer;
    void Awake()
    {
        Level = Manager.instance.levelShield;
    }
    public Shield()
    {
        Level = 1;
        CoolDown = 10;
        TimeActive = 3 + (Level - 1);
    }

    public AudioSource audioSource;
    
    public void Display()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
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
   
}
