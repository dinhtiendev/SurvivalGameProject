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

    void Start() {
        if (player == null)
        {
            player = Instantiate(playerPrefabs, new Vector3(0, 0, 0), Quaternion.identity);
        }
        score = 5;
        vsfollow.Follow = player.transform;
    }
}
