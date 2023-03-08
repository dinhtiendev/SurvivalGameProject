using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDestroy : MonoBehaviour
{
    public GameObject MonsterDestroyEffect;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Instantiate(MonsterDestroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
