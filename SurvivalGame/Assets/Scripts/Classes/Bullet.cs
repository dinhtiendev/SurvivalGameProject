using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bullet : MonoBehaviour
{
    public int Damanaged {get; set;}
    public float Speed {get; set;}

    Timer timer;
    Rigidbody2D rg2d;
    public AudioSource audioSource;

    void Awake()
    {
        timer = GetComponent<Timer>();
        rg2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!timer.isRunning())
        {
            Destroy(gameObject);
        }
    }

    public Bullet()
    {
        Damanaged = 20;
        Speed = 5f;
    }

    public void Move()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        timer.Duration(10f);
        timer.run();
        rg2d.velocity = new Vector2(Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad), Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad)) * 1f;
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
