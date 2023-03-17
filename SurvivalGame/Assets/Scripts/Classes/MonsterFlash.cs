using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFlash : MonoBehaviour
{
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
    public MonsterFlash()
    {
        Health = 20;
        Damanaged = 4;
        Speed = 15;
        Exp = 12;
    }

    public void Destroy()
    {
        Manager.instance.player.TakeExp(Exp);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Player player = Manager.instance.player;
            player.TakeDamage(Damanaged);
        }
    }
}
