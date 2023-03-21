using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartToInGame : MonoBehaviour
{
    public string sceneName;
    public Button countinue;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            countinue.gameObject.SetActive(true);
        }
        else
        {
            countinue.gameObject.SetActive(false);
        }
    }
    public void ChangeAndLoadScene()
    {
        LoadGame.loadGame(Manager.instance.player);
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitScene()
    {      
        Application.Quit();
    }
}
