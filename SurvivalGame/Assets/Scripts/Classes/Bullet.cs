using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damanaged {get; set;}
    public float Speed {get; set;}

    public Bullet()
    {
        Damanaged = 25;
        Speed = 10 * 5f;
    }

    public void Move()
    {
        Rigidbody2D rg2d = GetComponent<Rigidbody2D>();
        rg2d.velocity = new Vector2(Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad), Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad)) * Speed;
    }
}
