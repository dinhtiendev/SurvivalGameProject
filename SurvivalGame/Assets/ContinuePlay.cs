using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ContinuePlay : MonoBehaviour
{
    public string sceneName;
    public static int status = 0;
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
        SceneManager.LoadScene("Start Screen");
    }
    public void Save()
    {
    }
}
