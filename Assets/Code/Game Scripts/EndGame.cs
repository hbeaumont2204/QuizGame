using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.IO;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI previousScore;
    public TextMeshProUGUI highScore;
    string pScore;
    string hScore;
    void Start()
    {
        pScore = getScore("Assets/Files/Previous Score.txt");
        hScore = getScore("Assets/Files/High Score.txt");
        previousScore.text = "Previous Score:" + pScore.ToString();
        highScore.text = "High Score:" + hScore.ToString();
    }

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    string getScore(string path)
    {
        StreamReader sr = new StreamReader(path);
        string line = sr.ReadLine();
        return line;
    }
}
