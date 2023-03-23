using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField]
    GameObject monterX;

    [SerializeField]
    GameObject monterFlash;

    [SerializeField]
    GameObject monterTanker;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadGame(Player player, ButtonControl button)
    {

        if (!File.Exists("data.json"))
        {
            return;
        }

        string jsonData = File.ReadAllText("data.json");
        if (jsonData.Equals(string.Empty))
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
        Manager.instance.levelShield = data.levelShield;
        Manager.instance.levelHammer = data.levelHumber;
        Manager.instance.levelThunder = data.levelThunder;
        Manager.instance.score = data.score;
        Manager.instance.healthBar.SetMaxHealth(50);
        Manager.instance.healthBar.SetHealth(player.Health);
        Manager.instance.expBar.SetMaxExp(player.MaxExperience);
        Manager.instance.expBar.SetExp(player.CurExperience);

        
        int status = 0;
        if (data.levelShield != 0)
        {
            button.skillShield.GetComponentInChildren<Text>().text = "Level " + data.levelShield + Environment.NewLine + "Shield" + Environment.NewLine + "0s";
            button.skillShield.enabled = false;
            status = 1;
        }
        if (data.levelThunder != 0)
        {
            button.skillThunder.GetComponentInChildren<Text>().text = "Level " + data.levelThunder + Environment.NewLine + "Thunder" + Environment.NewLine + "0s";
            button.skillThunder.enabled = false;
            status = 1;
        }
        if (data.levelHumber != 0)
        {
            button.skillHammer.GetComponentInChildren<Text>().text = "Level " + data.levelHumber + Environment.NewLine + "Hammer" + Environment.NewLine + "0s";
            button.skillHammer.enabled = false;
            status = 1;
        }
        
        if (status == 1)
            Manager.instance.hideLevelUpSkills();


        foreach (var monster in data.Monster)
        {
            if (monster.typeMonster.Equals(TypeMonster.MonsterX))
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