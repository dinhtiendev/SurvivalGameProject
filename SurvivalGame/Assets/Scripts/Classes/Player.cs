using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    
    public int Health {get; set;}
    public int Damanaged { get; set; }
    public int Speed {get; set;}
    public int Level {get; set;}
    public int MaxExperience {get; set;}
    public int CurExperience {get; set; }

    public HealthBar healthBar;
    public ExpBar expBar;

    private float minX = -38.5f;
    private float maxX = 37.5f;
    private float minY = -23.5f;
    private float maxY = 21.5f;

    public Player()
    {
        Health = 50;
        Damanaged = 20;
        Speed = 8;
        Level = 1;
        MaxExperience = 100;
        CurExperience = 0;
    }

    Rigidbody2D rb;
    Vector2 move;
    public AudioSource takedamage;
    public AudioClip damages;
    public AudioSource monsterdeath;
    public AudioClip death;
    void Awake()
    {
        
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (CurExperience >= MaxExperience)
        {
            LevelUp();
        }
        if (Health < 0)
        {
            Destroy();
        }
    }

    public void Move()
    {
        
        FixedJoystick Joystick = Manager.instance.joystick;
        move.x = Joystick.Horizontal + Input.GetAxis("Horizontal");
        move.y = Joystick.Vertical + Input.GetAxis("Vertical");
        rb.Sleep();
        float hAxis = move.x;
        float vAxis = move.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        if (zAxis != 0)
        {
           
            transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
        }
        rb.MovePosition(rb.position + move * Speed * Time.deltaTime);
        if(gameObject.transform.position.x > maxX) 
        {
            gameObject.transform.position = new Vector2(maxX, gameObject.transform.position.y);
        }
        if (gameObject.transform.position.y > maxY)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, maxY);
        }
        if (gameObject.transform.position.x < minX)
        {
            gameObject.transform.position = new Vector2(minX, gameObject.transform.position.y);
        }
        if (gameObject.transform.position.y < minY)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, minY);
        }
    }

    public void TakeExp(int exp)
    {
        monsterdeath.PlayOneShot(death);
        CurExperience += exp;
        Debug.Log("Experience: " + CurExperience);
        expBar.SetExp(CurExperience);
    }

    public void TakeDamage(int damage)
    {
        takedamage.PlayOneShot(damages);
        Health -= damage;
        Debug.Log("Health: " + Health);
        healthBar.SetHealth(Health);
    }

    public void LevelUp()
    {
        Manager.instance.showLevelUpSkills();
        CurExperience -= MaxExperience;
        Level += 1;
        Debug.Log("Level: " + Level);
        MaxExperience = 100 + 100 * (Level - 1) * (Level - 1);
        expBar.SetMaxExp(MaxExperience);
        expBar.SetExp(CurExperience);
        Health = Mathf.RoundToInt(50 + 50 * (Level - 1) * 0.25f);
        healthBar.SetMaxHealth(Health);
        Damanaged = Mathf.RoundToInt(20 + (Level - 1) * 20 * 0.5f);
    }

    public void Destroy()
    {
        
        dontdestroy.score = Manager.instance.score;
        dontdestroy.level = Manager.instance.player.Level;
        SceneManager.LoadScene("Game Over Screen");
    }
}
