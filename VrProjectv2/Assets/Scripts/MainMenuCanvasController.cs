using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvasController : MonoBehaviour
{
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
