using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damanaged {get; set;}
    public int Speed {get; set;}

    public Bullet()
    {
        Damanaged = 25;
        Speed = 10 * 20;
    }
}
