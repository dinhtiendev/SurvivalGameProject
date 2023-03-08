using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFlash : MonoBehaviour
{
    public int Health { get; set; }
    public int Damanaged { get; set; }
    public int Speed { get; set; }
    public MonsterFlash()
    {
        Health = 20;
        Damanaged = 4;
        Speed = 15;
    }
}
