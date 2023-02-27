using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int Damanaged {get; set;}
    public int CoolDown {get; set;}
    public int TimeBack {get; set;}
    public int Speed {get; set;}
    public int Level {get; set;}

    public Hammer()
    {
        Damanaged = 25 * 2;
        CoolDown = 5;
        TimeBack = 2;
        Speed = 10;
        Level = 1;
    }
}
