using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    bool isPaused = false;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FPS()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pasue()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (isPaused)
        {
            Time.timeScale = 3f;
            isPaused = false;
        }
    }
    public void SlowTime()
    {
        if (Time.timeScale > 0.5f)
        {
            Time.timeScale -= 0.4f;
        }
    }
    public void FastTime()
    {
        if (Time.timeScale <= 15)
        {
            Time.timeScale += 0.5f;
        }
        else
        {
            Debug.Log(message: "You can not speed up time no more");
        }

    }

}