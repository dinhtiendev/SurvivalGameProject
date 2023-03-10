using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int CoolDown {get; set;}
    public int TimeActive {get; set;}
    public int Level {get; set;}

    public Shield()
    {
        CoolDown = 5;
        TimeActive = 3;
        Level = 1;
    }

    public void Display()
    {
        Rigidbody2D rg2d = GetComponent<Rigidbody2D>();

    }
}
