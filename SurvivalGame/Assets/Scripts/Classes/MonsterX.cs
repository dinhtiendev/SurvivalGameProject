using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterX : MonoBehaviour
{
    public int Health { get; set; }
    public int Damanaged { get; set; }
    public int Speed { get; set; }
    public int Exp { get; set; }
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
}
