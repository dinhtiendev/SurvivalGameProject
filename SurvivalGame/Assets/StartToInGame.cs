using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartToInGame : MonoBehaviour
{
    public string sceneName;
    public Button countinue;
    public static int status = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists("data.json") || File.ReadAllText("data.json").Equals(string.Empty))
        {
            countinue.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void ChangeAndLoadScene()
    {
        status = 1;
        //LoadGame.loadGame(Manager.instance.player);
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene()
    {
        if (File.Exists("data.json"))
        {
            File.WriteAllText("data.json",string.Empty);
            status = 0;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void ExitScene()
    {      
        Application.Quit();
    }
}
