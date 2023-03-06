using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    public int speed = 15;

    

   // [SerializeField]
   // GameObject player;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, new Vector3(1,1,1));
        Vector3 v = new Vector3(1, 1,1);
        Vector2 direction = v  - transform.position;

        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(1, 1), Time.deltaTime * speed);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
