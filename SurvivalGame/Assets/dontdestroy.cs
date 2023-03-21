using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    public GameObject player { get; set; }

    public GameObject[] monster { set; get; }
    public GameObject[] monster2 { set; get; }
    public GameObject[] monster3 { set; get; }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.FindGameObjectsWithTag("tanker") != null)
            monster = GameObject.FindGameObjectsWithTag("tanker");
        if (GameObject.FindGameObjectsWithTag("flasher") != null)
            monster2 = GameObject.FindGameObjectsWithTag("flasher");
        if (GameObject.FindGameObjectsWithTag("monster") != null)
            monster3 = GameObject.FindGameObjectsWithTag("monster");
    }
}
