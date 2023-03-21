using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Bullet bulletPrefabs;
    public Hammer hammerPrefabs;
    public Thunder thunderPrefabs;
    public Shield shieldPrefabs;

    private Bullet bullet;
    private Hammer hammer;
    private Thunder thunder;
    private Shield shield;

    public Button skillHammer;
    public Button skillThunder;
    public Button skillShield;

    public Timer timerHammer;
    public Timer timerThunder;
    public Timer timerShield;

    
    private void Awake()
    {
        timerHammer = timerHammer.AddComponent<Timer>();
        timerThunder = timerThunder.AddComponent<Timer>();
        timerShield = timerShield.AddComponent<Timer>();
        skillHammer.enabled = false;
        skillThunder.enabled = false;
        skillShield.enabled = false;
    }

    private void Update()
    {
        var player = Manager.instance.player;
        skillHammer.GetComponentInChildren<Text>().text = "Level " + Manager.instance.levelHammer + Environment.NewLine + "Hammer" + Environment.NewLine + timerHammer.getCount() + "s";
        skillThunder.GetComponentInChildren<Text>().text = "Level " + Manager.instance.levelThunder + Environment.NewLine + "Thunder" + Environment.NewLine + timerThunder.getCount() + "s";
        skillShield.GetComponentInChildren<Text>().text = "Level " + Manager.instance.levelHammer + Environment.NewLine + "Shield" + Environment.NewLine + timerShield.getCount() + "s";
        if (!timerHammer.isRunning() && Manager.instance.levelHammer > 0)
        {
            skillHammer.GetComponentInChildren<Text>().text = "Level " + Manager.instance.levelHammer + Environment.NewLine + "Hammer";
            skillHammer.enabled = true;
        }
        if (!timerThunder.isRunning() && Manager.instance.levelThunder > 0)
        {
            skillThunder.GetComponentInChildren<Text>().text = "Level " + Manager.instance.levelThunder + Environment.NewLine + "Thunder";
            skillThunder.enabled = true;
        }
        if (!timerShield.isRunning() && Manager.instance.levelShield > 0)
        {
            skillShield.GetComponentInChildren<Text>().text = "Level " + Manager.instance.levelShield + Environment.NewLine + "Shield";
            skillShield.enabled = true;
        }
    }

    public void Shot()
    {
        Player player = Manager.instance.player;
        Vector3 pos = new Vector3(player.transform.position.x + Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad), player.transform.position.y + Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad), 0);
        bullet = Instantiate(bulletPrefabs, pos, Quaternion.identity);
        bullet.Move();
    }

    public void HammerSkills()
    {
        Player player = Manager.instance.player;
        Vector3 pos = new Vector3(player.transform.position.x + Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad) * 1.1f, player.transform.position.y + Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad) * 1.1f, player.transform.position.z);
        hammer = Instantiate(hammerPrefabs, pos, Quaternion.identity);
        hammer.transform.rotation = Quaternion.Euler(0f, 0f, -Manager.instance.zAxis);
        hammer.Move();
        skillHammer.enabled = false;
        timerHammer.Duration(hammer.CoolDown);
        timerHammer.run();
    }

    public void ThunderSkills()
    {

        Player player = Manager.instance.player;
        Vector2 v = player.transform.position;
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
        if (monster.Length > 5)
        {
            for (int i = 0; i < monster.Length - 1; i++)
            {
                for (int j = 0; j < monster.Length - i - 1; j++)
                {
                    if (Vector2.Distance(v, monster[j].transform.position) > Vector2.Distance(v, monster[j + 1].transform.position))
                    {
                        GameObject temp = monster[j];
                        monster[j] = monster[j + 1];
                        monster[j + 1] = temp;
                    }
                }
            }
        }
        for (int j = 0; j < monster.Length; j++)
        {
            if (j > 4)
            {
                break;
            }
            // create 5 thunder on monster's head that closest
            thunder = Instantiate(thunderPrefabs, monster[j].transform.position + (Vector3.up*1.5f), Quaternion.identity);
            thunder.Display();
            if (j == 0)
            {
                skillThunder.enabled = false;
                timerThunder.Duration(thunder.CoolDown);
                timerThunder.run();
            }
            
            if (monster[j].GetComponent<MonsterTanker>() != null)
            {
                MonsterTanker m = monster[j].GetComponent<MonsterTanker>();
                m.Health -= thunder.Damanaged;
                if (m.Health <= 0)
                {
                    player.TakeExp(m.Exp);
                    Destroy(monster[j]);
                }
            }
            else if (monster[j].GetComponent<MonsterFlash>() != null)
            {
                MonsterFlash m = monster[j].GetComponent<MonsterFlash>();
                m.Health -= thunder.Damanaged;
                if(m.Health <= 0)
                {
                    player.TakeExp(m.Exp);
                    Destroy(monster[j]);
                }
            }
            else if(monster[j].GetComponent<MonsterX>() != null)
            {
                MonsterX m = monster[j].GetComponent<MonsterX>();
                m.Health -= thunder.Damanaged;
                if (m.Health <= 0)
                { 
                    player.TakeExp(m.Exp);
                    Destroy(monster[j]);
                   
                }
            }
        }
        
    }

    public void ShieldSkills()
    {      
        Player player = Manager.instance.player;
        shield = Instantiate(shieldPrefabs, player.transform.position, Quaternion.identity);
        shield.Display();
        skillShield.enabled = false;
        timerShield.Duration(shield.CoolDown);
        timerShield.run();
    }

    public void LevelUpHammer()
    {
        Manager.instance.levelHammer += 1;
        Manager.instance.hideLevelUpSkills();
    }

    public void LevelUpThunder()
    {
        Manager.instance.levelThunder += 1;
        Manager.instance.hideLevelUpSkills();
    }

    public void LevelUpShield()
    {
        Manager.instance.levelShield += 1;
        Manager.instance.hideLevelUpSkills();
    }

}
