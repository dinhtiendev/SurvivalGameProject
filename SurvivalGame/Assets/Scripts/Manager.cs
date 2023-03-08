using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public int score;
    public Player playerPrefabs;
    public CinemachineVirtualCamera vsfollow;
    public Player player;
    public FixedJoystick joystick;
    public float zAxis = 0f;
    void Start() {
        if (player == null)
        {
            player = Instantiate(playerPrefabs, new Vector3(0, 0, 0), Quaternion.identity);
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
