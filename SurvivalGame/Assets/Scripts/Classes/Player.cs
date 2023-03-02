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
}
