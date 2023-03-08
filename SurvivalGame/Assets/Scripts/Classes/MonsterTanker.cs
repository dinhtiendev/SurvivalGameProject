using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTanker : MonoBehaviour
{
    public int Health { get; set; }
    public int Damanaged { get; set; }
    public int Speed { get; set; }
    public MonsterTanker()
    {
        Health = 40;
        Damanaged = 7;
        Speed = 5;
    }
}
