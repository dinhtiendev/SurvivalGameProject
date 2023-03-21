using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyMonster 
{
    public TypeMonster typeMonster { set; get; }
    public int Health { get; set; }
    public int Damanaged { get; set; }
    public int Speed { get; set; }
    public int Exp { get; set; }

    public float PosX { get; set; }
    public float PosY { get; set; }
    
    public float rotateZ { get; set; }
}
public enum TypeMonster
    {
    MonsterX, MonsterFlash, MonsterTanker
    }