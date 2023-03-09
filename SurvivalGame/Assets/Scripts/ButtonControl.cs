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
        Player player = Manager.instance.player;
        hammer = Instantiate(hammerPrefabs, player.transform.position, Quaternion.identity);
        hammer.Move();
    }

    public void ThunderSkills()
    {
        Player player = Manager.instance.player;
        thunder = Instantiate(thunderPrefabs, player.transform.position, Quaternion.identity);
        thunder.Display();
    }

    public void ShieldSkills()
    {
        Player player = Manager.instance.player;
        shield = Instantiate(shieldPrefabs, player.transform.position, Quaternion.identity);
        shield.Display();
    }
}
