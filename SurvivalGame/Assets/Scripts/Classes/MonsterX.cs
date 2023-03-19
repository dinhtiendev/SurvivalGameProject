using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterX : MonoBehaviour
{

    private float lastAttackTime;
    private const float attackDelay = 2f;
    public int Health { get; set; }
    public int Damanaged { get; set; }
    public int Speed { get; set; }
    public int Exp { get; set; }

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.Sleep();
    }
    public MonsterX()
    {
        Health = 25;
        Damanaged = 5;
        Speed = 7;
        Exp = 10;
    }

    
    public void Destroy()
    {
        Manager.instance.player.TakeExp(Exp);
        Destroy(gameObject);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && Time.time - lastAttackTime > attackDelay)
        {
            Player player = Manager.instance.player;
            player.TakeDamage(Damanaged);
            lastAttackTime = Time.time;
        }
    }
}
