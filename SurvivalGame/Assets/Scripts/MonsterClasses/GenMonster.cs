using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMonster : MonoBehaviour
{
    private int levelPlayer;

    private float minX = -36;
    private float maxX = 36;
    private float minY = -22;
    private float maxY = 19;
    private int [] monsterPercentages;

    [SerializeField]
    GameObject[] monsters;

    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.Duration(2);
        timer.run();
        monsterPercentages = new int[3];
        monsterPercentages[0] = 30;//tanker
        monsterPercentages[1] = 10;//speed 
        monsterPercentages[2] = 60;//normal 
    }

    public void GenRandomMonster()
    {
       
        for (int j = 0; j < 10; j++)
        { 
            int randomPercentage = Random.Range(0, 100);
            for (int i = 0; i < monsters.Length; i++)
            {
                randomPercentage -= monsterPercentages[i];
                if (randomPercentage < 1)
                {
                    float y = Random.Range(minY, maxY+1);
                    y -= (y + maxY);
                    Instantiate(monsters[i], new Vector2(Random.Range(minX, maxX+1), y), Quaternion.identity);
                    break;
                }
                
            }
        }
    }
      
        // Update is called once per frame
        void Update()
        {
        if (!timer.isRunning())
        {
            GenRandomMonster();
            timer.Duration(15);
            timer.run();
        }
        }
}
