using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevelandScore : MonoBehaviour
{
    public static GetLevelandScore instance { get; set; }

    public int score = Manager.instance.score;
    public int lv = Manager.instance.player.Level;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
