using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damanaged {get; set;}
    public float Speed {get; set;}

    Timer timer;
    Rigidbody2D rg2d;

    void Awake()
    {
        timer = GetComponent<Timer>();
        rg2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!timer.isRunning())
        {
            Destroy(gameObject);
        }
    }

    public Bullet()
    {
        Damanaged = 25;
        Speed = 10 * 5f;
    }

    public void Move()
    {
        timer.Duration(10f);
        timer.run();
        rg2d.velocity = new Vector2(Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad), Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad)) * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("MonsterFlash"))
        {
            MonsterFlash monster = collision.gameObject.GetComponent<MonsterFlash>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("MonsterTanker"))
        {
            MonsterTanker monster = collision.gameObject.GetComponent<MonsterTanker>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("MonsterX"))
        {
            MonsterX monster = collision.gameObject.GetComponent<MonsterX>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
