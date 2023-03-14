using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    public int speed;

    private Player player;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = Manager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flasher") ||
            collision.gameObject.CompareTag("tanker") ||
            collision.gameObject.CompareTag("monster")||
            collision.gameObject.CompareTag("Player"))
        {
            
        }
        else
        {
          GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("flasher") ||
            collision.gameObject.CompareTag("tanker") ||
            collision.gameObject.CompareTag("monster") ||
            collision.gameObject.CompareTag("Player"))
        {
            GetComponent<PolygonCollider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }
}
