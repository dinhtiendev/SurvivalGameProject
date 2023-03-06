using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    FixedJoystick Joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Joystick = (FixedJoystick)FindObjectOfType(typeof(FixedJoystick));
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        float hAxis = move.x;
        float vAxis = move.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }
}
