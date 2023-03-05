using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public GameObject player;
    public FixedJoystick Joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        
        playerObject = Instantiate(player);
        playerObject.transform.position = new Vector3(0, 0, 0);
        playerObject.transform.rotation = Quaternion.identity;
        rb = playerObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        float hAxis = move.x;
        float vAxis = move.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        playerObject.transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }
}
