using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI score;

    [SerializeField]
    public TextMeshProUGUI level;
    // Start is called before the first frame update
    void Start()
    {
        dontdestroy d =  GameObject.FindGameObjectWithTag("dontdestroy").GetComponent<dontdestroy>();
        score.text="Level: " + d.level;
        level.text = "Score: " + d.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
