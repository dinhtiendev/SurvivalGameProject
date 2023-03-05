using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRigidbody2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
