using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTanker : MonoBehaviour
{
    private int baseHealth = 40;
    private int baseDamanaged = 7;
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
        Move();
    }
    public MonsterTanker()
    {
        Player player = Manager.instance.player;
        int playerLevel = player.Level;
        Health = Mathf.RoundToInt(baseHealth + ((playerLevel - 1) * baseDamage * 0.3f));
        Damanaged = Mathf.RoundToInt(baseDamanaged + ((playerLevel - 1) * baseDamanaged * 0.3f));
        Speed = 3;
        Exp = 15;
    }

    public void Move()
    {
        Player player = Manager.instance.player;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * Speed);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
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
