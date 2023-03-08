using System.Collections;
using System.Collections.Generic;
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
        //hammer = Instantiate(hammerPrefabs, player.transform.position + player.transform.localScale, Quaternion.identity);
    }
}
