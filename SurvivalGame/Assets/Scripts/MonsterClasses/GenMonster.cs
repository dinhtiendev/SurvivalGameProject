using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMonster : MonoBehaviour
{
    private int levelPlayer;
    private float minX = -27;
    private float maxX = 27;
    private float minY = -13;
    private float maxY = 13;
    private float[] monsterPercentages;
    [SerializeField]
    GameObject[] monsters;
    public int count;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.Duration(2);
        timer.run();
        monsterPercentages = new float[3];
        monsterPercentages[0] = 30;//tanker
        monsterPercentages[1] = 10;//speed 
        monsterPercentages[2] = 60;//normal 
    }

    public void GenRandomMonster()
    {
        for (int j = 0; j < 10; j++)
        {
            float randomPercentage = Random.Range(0, 100f);
            for (int i = 0; i < monsters.Length; i++)
            {
                if (randomPercentage < 1f)
                {
                    count++;
                    if (Random.Range(1, 3) == 1)
                    {
                        float y = Random.Range(minY, maxY+1);
                        y -= (y + maxY);
                        Instantiate(monsters[i], new Vector2(Random.Range(minX, maxX+1), y), Quaternion.identity);
                    }
                    else
                    {
                        float x = Random.Range(minX, maxX+1);
                        x -= (x + maxX);
                        Instantiate(monsters[i], new Vector2(x, Random.Range(minY, maxY+1)), Quaternion.identity); 
                    }
                    break;
                }
                randomPercentage -= monsterPercentages[i];
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
