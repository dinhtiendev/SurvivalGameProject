using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health {get; set;}
    public int Damanaged {get; set;}
    public int Speed {get; set;}
    public int Level {get; set;}
    public int MaxExperience {get; set;}
    public int CurExperience {get; set; }

    public HealthBar healthBar;
    public ExpBar expBar;

    public Player()
    {
        Health = 50;
        Damanaged = 25;
        Speed = 20;
        Level = 1;
        MaxExperience = 100;
        CurExperience = 0;
    }

    Rigidbody2D rb;
    Vector2 move;

    void Awake()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (CurExperience >= MaxExperience)
        {
            LevelUp();
        }
        if (Health < 0)
        {
            Destroy();
        }
    }

    public void Move()
    {
        FixedJoystick Joystick = Manager.instance.joystick;
        move.x = Joystick.Horizontal + Input.GetAxis("Horizontal");
        move.y = Joystick.Vertical + Input.GetAxis("Vertical");

        float hAxis = move.x;
        float vAxis = move.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        if (zAxis != 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
        }
        rb.MovePosition(rb.position + move * Speed * Time.deltaTime);
    }

    public void TakeExp(int exp)
    {
        CurExperience += exp;
        expBar.SetExp(CurExperience);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.SetHealth(Health);
    }

    public void LevelUp()
    {
        CurExperience -= MaxExperience;
        expBar.SetExp(CurExperience);
        Level += 1;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
