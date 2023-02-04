using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int startScene;
    public int optionScene;

    public void StartGame() 
    {
        SceneManager.LoadScene(startScene);
    }

    public void Options()
    {
        SceneManager.LoadScene(optionScene);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}