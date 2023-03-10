using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public int Damanaged {get; set;}
    public int CoolDown {get; set;}
    public int Level {get; set;}

    public Thunder()
    {
        Damanaged = 25 * 3;
        CoolDown = 3;
        Level = 1;
    }

    public void Display()
    {
        Rigidbody2D rg2d = GetComponent<Rigidbody2D>();
    }
}
