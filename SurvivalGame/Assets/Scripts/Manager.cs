using Cinemachine;
using System.Collections;
using System.Collections.Generic;
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
    
    public float zAxis = 0f;
    void Start() {
        if (player == null)
        {
            player = Instantiate(playerPrefabs, new Vector3(0, 0, 0), Quaternion.identity);
            player.healthBar = healthBar;
            player.expBar = expBar;
            healthBar.SetMaxHealth(player.Health);
            expBar.SetMaxExp(player.MaxExperience);
        }
        if (joystick == null)
        {
            joystick = (FixedJoystick)FindObjectOfType(typeof(FixedJoystick));
        }
        vsfollow.Follow = player.transform;
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
}
