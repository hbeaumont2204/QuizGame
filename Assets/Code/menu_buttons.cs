using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_buttons : MonoBehaviour
{
    public void new_game()
    {

    }
    public void play_game()
    {
        SceneManager.LoadSceneAsync("Level Menu");
    }
    public void quit_game()
    {
        Application.Quit();
    }
    public void mainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}