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
        String hScorePath = "Assets/Files/High Score.txt";
        pScore = getScore("Assets/Files/Previous Score.txt");
        hScore = getScore(hScorePath);
        previousScore.text = "Previous Score: " + pScore.ToString();
        if (Convert.ToInt32(pScore) > Convert.ToInt32(hScore))
        {
            highScore.text = "High Score: " + pScore.ToString();
            updateHighScore(pScore, hScorePath);
        }
        else
        {
            highScore.text = "High Score: " + hScore.ToString();
        }

    }

    public void updateHighScore(string text, string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(text);
        }
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
