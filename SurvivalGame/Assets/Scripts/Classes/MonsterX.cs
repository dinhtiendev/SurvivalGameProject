using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterX : MonoBehaviour
{
    public int Health { get; set; }
    public int Damanaged { get; set; }
    public int Speed { get; set; }
    public MonsterX()
    {
        Health = 25;
        Damanaged = 5;
        Speed = 7;
    }


}
