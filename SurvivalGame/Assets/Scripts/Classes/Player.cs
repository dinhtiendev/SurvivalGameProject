using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health {get; set;}
    public int Damanaged {get; set;}
    public int Speed {get; set;}
    public int Level {get; set;}
    public int Experience {get; set;}

    public Player()
    {
        Health = 50;
        Damanaged = 25;
        Speed = 10;
        Level = 1;
        Experience = 100;
    }

    Rigidbody2D rb;
    Vector2 move;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
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
}
