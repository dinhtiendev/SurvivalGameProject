using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Manager : Singleton<Manager>
{
    public Player playerPrefabs;
    public CinemachineVirtualCamera vsfollow;
    public HealthBar healthBar;
    public ExpBar expBar;
    public Player player;
    public FixedJoystick joystick;
    public int levelHammer;
    public int levelThunder;
    public int levelShield;

    public Button levelUpHammer;
    public Button levelUpThunder;
    public Button levelUpShield;
    public bool gameStart = false;

    public int score;

    [SerializeField]
    LoadGame loadGame;
    public float zAxis = 0f;
    void Start() {
        score = 0;
        loadGame = GetComponent<LoadGame>();
        if (player == null)
        {
            player = Instantiate(playerPrefabs, new Vector3(0, 0, 0), Quaternion.identity);
            player.healthBar = healthBar;
            player.expBar = expBar;
            healthBar.SetMaxHealth(player.Health);
            expBar.SetMaxExp(player.MaxExperience);
        }
        try
        {
            if (ContinuePlay.status == 1)
            {
                loadGame.loadGame(player);
                ContinuePlay.status = 0;
                if (File.Exists("data.json"))
                {
                    File.WriteAllText("data.json", string.Empty);
                }
            }
        }catch(Exception e)
        {
            if (File.Exists("data.json"))
            {
                File.WriteAllText("data.json", string.Empty);
            }
        }
        if (joystick == null)
        {
            joystick = (FixedJoystick)FindObjectOfType(typeof(FixedJoystick));
        }
        vsfollow.Follow = player.transform;
        levelHammer = 0;
        levelThunder = 0;
        levelShield = 0;
        showLevelUpSkills();
    }

    void Update()
    {
        
        float x = joystick.Horizontal + Input.GetAxis("Horizontal");
        float y = joystick.Vertical + Input.GetAxis("Vertical");
        if (x != 0 || y != 0)
        {
            zAxis = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
        }
    }

    public void showLevelUpSkills()
    {
        levelUpHammer.gameObject.SetActive(true);
        levelUpThunder.gameObject.SetActive(true);
        levelUpShield.gameObject.SetActive(true);
    }

    public void hideLevelUpSkills()
    {
        levelUpHammer.gameObject.SetActive(false);
        levelUpThunder.gameObject.SetActive(false);
        levelUpShield.gameObject.SetActive(false);
    }
}
