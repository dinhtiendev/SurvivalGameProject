using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public void Shot()
    {
        Player player = Manager.instance.player;
        bullet = Instantiate(bulletPrefabs, player.transform.position, Quaternion.identity);
        bullet.Move();
    }

    public void HammerSkills()
    {
        Player player = Manager.instance.player;
        hammer = Instantiate(hammerPrefabs, player.transform.position, Quaternion.identity);
        hammer.Move();
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
        }
        
    }

    public void ShieldSkills()
    {
        Player player = Manager.instance.player;
        shield = Instantiate(shieldPrefabs, player.transform.position, Quaternion.identity);
        shield.Display();
    }
}
