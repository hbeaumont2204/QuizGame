using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_buttons : MonoBehaviour
{
    // Main Menu buttons
    public void play_game()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void quit_game()
    {
        Application.Quit();
    }
    // Pause Menu buttons
    public void main_menu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}