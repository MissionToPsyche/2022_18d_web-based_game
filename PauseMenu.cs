using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] AudioSource bg;
    public int mainMenu;
    private bool isPaused;

    //Hotkey for pausing
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Set time to 0, pause music, and show pause menu
    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        bg.Pause();
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        bg.Play();
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
