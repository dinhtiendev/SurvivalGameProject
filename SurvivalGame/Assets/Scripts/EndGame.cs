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
       
        score.text="Score: " + dontdestroy.score;
        level.text = "Level: " + dontdestroy.level;
        Debug.Log("score" + dontdestroy.score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
