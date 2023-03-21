using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenMonster : MonoBehaviour
{
    private int levelPlayer;

    private float minX = -38;
    private float maxX = 38;
    private float minY = -25;
    private float maxY = 23;

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
        monsterPercentages[0] = 70;//normal
        monsterPercentages[1] = 20;//speed 
        monsterPercentages[2] = 10;//tanker 
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
                    int random = Random.Range(1, 5);
                    float x, y;
                    if(random == 1)
                    {
                        y = maxY;
                        x = Random.Range(minX, maxX);
                    }
                    else if (random == 2)
                    {
                        x = maxX;
                        y = Random.Range(minY, maxY);
                    }
                    else if(random == 3)
                    {
                        y = minY;
                        x = Random.Range(minX, maxX);
                    }
                    else
                    {
                        x = minX;
                        y = Random.Range(minY, maxY);
                    }

                    Instantiate(monsters[i], new Vector2(x, y), Quaternion.identity);
                    break;
                }
                
            }
        }
    }
      
        // Update is called once per frame
        void Update()
        {
        if (!timer.isRunning() && getSize() <= 20)
        {
            GenRandomMonster();
            timer.Duration(20);
            timer.run();
        }
        }
    public int getSize()
    {
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
        return monster == null ? 0 : monster.Length;
    }
}
