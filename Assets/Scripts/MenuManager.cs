using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int mainMenu;
    public int startScene;
    public int optionScene;
    public int disclaimerScene;

    public void StartGame() 
    {
        SceneManager.LoadScene(startScene);
    }

    public void Options()
    {
        SceneManager.LoadScene(optionScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Disclaimer()
    {
        SceneManager.LoadScene(disclaimerScene);
    }
}
