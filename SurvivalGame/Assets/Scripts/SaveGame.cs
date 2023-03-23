using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UIElements;

public class SaveGame : MonoBehaviour
{
 

    private static void createFile()
    {
        if (!File.Exists("data.json"))
        {
           File.Create("data.json");
        }
    }

    public void SetData()
    {
        createFile();
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player == null)
        {
            return;
        }
        PropertyPlayer propertyPlayer = new PropertyPlayer()
        {
            CurExperience = player.CurExperience,
            Health = player.Health,
            Level= player.Level,
            MaxExperience= player.MaxExperience,
            PosY = GameObject.FindGameObjectWithTag("Player").transform.position.y,
            PosX = GameObject.FindGameObjectWithTag("Player").transform.position.x,
            Speed = player.Speed
        };
        ///////////////////////
        GameObject[] monster = GameObject.FindGameObjectsWithTag("tanker");
        GameObject[] monster2 = GameObject.FindGameObjectsWithTag("flasher");
        GameObject[] monster3 = GameObject.FindGameObjectsWithTag("monster");
        if (monster == null)
        {
            monster = new GameObject[0];
        }
        if (monster2 != null)
        {
            monster = monster.Concat(monster2).ToArray();
        }
        if (monster3 != null)
        {
            monster = monster.Concat(monster3).ToArray();
        }
        if(monster == null)
        {
            return;
        }
        List<PropertyMonster> monsters = new List<PropertyMonster>();
        ///////////////////////
        for (int j = 0; j < monster.Length; j++) 
        {
            PropertyMonster propertyMonster;
            if (monster[j].GetComponent<MonsterTanker>() != null)
              {
                MonsterTanker m = monster[j].GetComponent<MonsterTanker>();
                propertyMonster = new PropertyMonster()
                {
                    Damanaged = m.Damanaged,
                    Exp = m.Exp,
                    Health = m.Health,
                    Speed= m.Speed,
                    typeMonster = TypeMonster.MonsterTanker,
                    PosX = monster[j].transform.position.x,
                    PosY = monster[j].transform.position.y,
                    rotateZ = monster[j].transform.rotation.z,
                };
              }
            else if (monster[j].GetComponent<MonsterFlash>() != null)
              {
                MonsterFlash m = monster[j].GetComponent<MonsterFlash>();
                propertyMonster = new PropertyMonster()
                {
                    Damanaged = m.Damanaged,
                    Exp = m.Exp,
                    Health = m.Health,
                    Speed = m.Speed,
                    typeMonster = TypeMonster.MonsterFlash,
                    PosX = monster[j].transform.position.x,
                    PosY = monster[j].transform.position.y,
                    rotateZ = monster[j].transform.rotation.z,
                };
              }
            else 
             {
                MonsterX m = monster[j].GetComponent<MonsterX>();
                propertyMonster = new PropertyMonster()
                {
                    Damanaged = m.Damanaged,
                    Exp = m.Exp,
                    Health = m.Health,
                    Speed = m.Speed,
                    typeMonster = TypeMonster.MonsterX,
                    PosX = monster[j].transform.position.x,
                    PosY = monster[j].transform.position.y,
                    rotateZ = monster[j].transform.rotation.z,
                };
              }
            monsters.Add(propertyMonster);

        }
        ///////////////////////////
        propertyPlayer.Monster = monsters;
        //////////////////////////
        if (Manager.instance != null)
        {
            propertyPlayer.levelHumber = Manager.instance.levelHammer;
            propertyPlayer.levelThunder = Manager.instance.levelThunder;
            propertyPlayer.levelShield = Manager.instance.levelShield;
            propertyPlayer.score= Manager.instance.score;
        }

        string data = JsonConvert.SerializeObject(propertyPlayer);
        File.WriteAllText("data.json", data);
    }
    
}
