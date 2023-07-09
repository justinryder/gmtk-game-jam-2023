using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void LoadCredits()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Credits");
    }
}
