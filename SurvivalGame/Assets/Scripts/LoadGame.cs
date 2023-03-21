using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    [SerializeField]
    static GameObject monterX;

    [SerializeField]
    static GameObject monterFlash;

    [SerializeField]
    static GameObject monterTanker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void loadGame(Player player)
    {

        if (!File.Exists("data.json"))
        {
            return;
        }

        string jsonData = File.ReadAllText("data.json");
        if(jsonData.Equals(string.Empty))
        {
            return;
        }
        PropertyPlayer data = JsonConvert.DeserializeObject<PropertyPlayer>(jsonData);

        player.CurExperience = data.CurExperience;
        player.MaxExperience = data.MaxExperience;
        player.Level = data.Level;
        player.Speed = data.Speed;
        player.Health = data.Health;
        player.transform.position = new Vector2(data.PosX, data.PosY);

        foreach(var monster in data.Monster)
        {
            if(monster.typeMonster.Equals(TypeMonster.MonsterX))
            {
                Instantiate(monterX, new Vector2(monster.PosX, monster.PosY), Quaternion.Euler(0, 0, monster.rotateZ));
            }
            else if (monster.typeMonster.Equals(TypeMonster.MonsterTanker))
            {
                Instantiate(monterTanker, new Vector2(monster.PosX, monster.PosY), Quaternion.Euler(0, 0, monster.rotateZ));
            }
            else
            {
                Instantiate(monterFlash, new Vector2(monster.PosX, monster.PosY), Quaternion.Euler(0, 0, monster.rotateZ));
            }
        }
    }
}
