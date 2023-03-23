using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyPlayer 
{
    public int Health { get; set; }
    public int Speed { get; set; }
    public int Level { get; set; }
    public int MaxExperience { get; set; }
    public int CurExperience { get; set; }
    public float PosX { get; set; }
    public float PosY { get; set; }
    public List<PropertyMonster> Monster { get; set; }

    public int levelHumber { get; set; }
    public int levelThunder { get; set; }
    public int levelShield { get; set; }
    public int score { get; set; }
}
