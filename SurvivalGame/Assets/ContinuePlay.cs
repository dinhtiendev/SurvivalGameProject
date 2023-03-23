using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ContinuePlay : MonoBehaviour
{
    public string sceneName;
    public static int status = 0;
    public TextMeshProUGUI lv;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSceneInContinue()
    {
        status = 1;
        SceneManager.LoadScene(sceneName);
    }
    public void SaveAndExist()
    {
        ContinuePlay.status = 0;
        SceneManager.LoadScene("Start Screen");
    }
    public void Save()
    {
    }
}
