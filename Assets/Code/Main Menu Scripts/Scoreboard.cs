using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.IO;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI previousScore;
    public TextMeshProUGUI highScore;

    string pScore;
    string hScore;
    string hScorePath = Path.Combine(Application.streamingAssetsPath, "High Score.txt");
    string pScorePath = Path.Combine(Application.streamingAssetsPath, "Previous Score.txt");
    void Start()
    {
        pScore = getScore(pScorePath);
        hScore = getScore(hScorePath);
        previousScore.text = "Previous Score: " + pScore.ToString();
        highScore.text = "High Score: " + hScore.ToString();
    }

    string getScore(string path)
    {
        StreamReader sr = new StreamReader(path);
        string line = sr.ReadLine();
        return line;
    }
}
