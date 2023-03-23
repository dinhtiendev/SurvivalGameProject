using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameToPause : MonoBehaviour
{
    SaveGame saveGame;
    public string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        saveGame = GetComponent<SaveGame>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeScene()
    {    
        saveGame.SetData();
        SceneManager.LoadScene(sceneName);
    }
}
