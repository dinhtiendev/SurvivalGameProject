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
        Damanaged = 20;
        Speed = 10 * 5f;
    }

    public void Move()
    {
        timer.Duration(10f);
        timer.run();
        rg2d.velocity = new Vector2(Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad), Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad)) * Speed;
    }

    public void LevelUp()
    {
        Player player = Manager.instance.player;
        Damanaged = Mathf.RoundToInt(20 + 20 * (player.Level - 1) * 0.25f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("flasher"))
        {
            MonsterFlash monster = collision.gameObject.GetComponent<MonsterFlash>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                monster.Destroy();
            }
        } else if (collision.gameObject.CompareTag("tanker"))
        {
            MonsterTanker monster = collision.gameObject.GetComponent<MonsterTanker>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                monster.Destroy();
            }
        } else if (collision.gameObject.CompareTag("monster"))
        {
            MonsterX monster = collision.gameObject.GetComponent<MonsterX>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                monster.Destroy();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("flasher"))
        {
            MonsterFlash monster = collision.gameObject.GetComponent<MonsterFlash>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                monster.Destroy();
            }
        }
        else if (collision.gameObject.CompareTag("tanker"))
        {
            MonsterTanker monster = collision.gameObject.GetComponent<MonsterTanker>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                monster.Destroy();
            }
        }
        else if (collision.gameObject.CompareTag("monster"))
        {
            MonsterX monster = collision.gameObject.GetComponent<MonsterX>();
            monster.Health -= Damanaged;
            if (monster.Health <= 0)
            {
                monster.Destroy();
            }
        }
    }
}
