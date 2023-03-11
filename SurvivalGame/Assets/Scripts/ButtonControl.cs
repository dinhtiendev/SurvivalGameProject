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
        Vector3 pos = new Vector3(player.transform.position.x + Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad), player.transform.position.y + Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad), player.transform.position.z);
        bullet = Instantiate(bulletPrefabs, pos, Quaternion.identity);
        bullet.Move();
    }

    public void HammerSkills()
    {
        Player player = Manager.instance.player;
        Vector3 pos = new Vector3(player.transform.position.x + Mathf.Sin(Manager.instance.zAxis * Mathf.Deg2Rad) * 1.1f, player.transform.position.y + Mathf.Cos(Manager.instance.zAxis * Mathf.Deg2Rad) * 1.1f, player.transform.position.z);
        hammer = Instantiate(hammerPrefabs, pos, Quaternion.identity);
        hammer.transform.rotation = Quaternion.Euler(0f, 0f, -Manager.instance.zAxis);
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
