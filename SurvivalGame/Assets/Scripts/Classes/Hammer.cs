using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hammer : MonoBehaviour
{
    public int Damanaged {get; set;}
    public int CoolDown {get; set;}
    public int TimeBack {get; set;}
    public float Speed {get; set;}
    public int Level {get; set;}

    Timer timerBack;
    Rigidbody2D rg2d;
    public AudioSource audioSource;
    void Awake()
    {
        timerBack = GetComponent<Timer>();
        rg2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!timerBack.isRunning())
        {
            Vector3 pos = new Vector3(Manager.instance.player.transform.position.x + Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad) * 1.1f, Manager.instance.player.transform.position.y + Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad) * 1.1f, 0);
            rg2d.velocity = new Vector2(0, 0);
            transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * Speed);
            transform.up = -transform.position;
            if (transform.position == pos)
            {
                Destroy(gameObject);
            }
        }
    }

    public Hammer()
    {
        Level = Manager.instance.levelHammer;
        Damanaged = 30 + Mathf.RoundToInt(Damanaged * (Level - 1) * 0.25f);
        CoolDown = 5;
        TimeBack = 2;
        Speed = 10;
    }

    public void Move()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        timerBack.Duration(TimeBack);
        timerBack.run();
        rg2d.velocity = new Vector2(Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad), Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad)) * Speed;
    }

    public void LevelUp()
    {
        Level += 1;
        Damanaged = 30 + Mathf.RoundToInt(Damanaged * (Level - 1) * 0.25f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
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
        } else
        {

        }
    }
}
