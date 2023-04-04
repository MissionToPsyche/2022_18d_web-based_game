using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    public int mainMenu;
    [SerializeField] AudioSource bg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If player is destroyed, show game over panel
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOver.SetActive(true);
            bg.Pause();
        }
    }

    //Restart and main menu buttons
    public void Restart()
    {
        //Reload previous scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        bg.Play();
    }

    public void Home()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
