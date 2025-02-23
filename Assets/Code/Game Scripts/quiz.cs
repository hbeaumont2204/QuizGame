using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.IO;
using System;

public class quiz  : MonoBehaviour
{
    public question[] questions;
    public int currentQuestionNumber = 0;
    question currentQuestion;
    public int score = 0;
    float timer = 30;
    
    public Text questionDisplay;
    public Text scoreDisplay;
    public Text resultDisplay;
    
    // Called at the start
    private void Start()
    {
        setup();
    }

    // Called every frame
    void Update()
    {
        timer = timer - Time.deltaTime;
    }

    void setup()
    {
        string[] allQuestions;
        string[][] allChoices;
        string[] allAnswers;
        
    }

    string[] ReadFile(string path)
    {
        string[] data = { };
        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Array.Resize(ref data, data.Length + 1);
                    data[data.Length - 1] = line;
                    Debug.Log(line);
                }
            }
        }
        else
        {
            Debug.Log("Error");
        }
        return data;
    }

    string[][] GetChoices(string path)
    {
        string[][] data = { };
        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] options = line.Split(',');
                    Array.Resize(ref data, data.Length + 1);
                    data[data.Length - 1] = options;
                    Debug.Log(line);
                }
                
            }
        }
        else
        {
            Debug.Log("Error");
        }
        return data;
    }

    void displayQuestion()
    {
        if (currentQuestionNumber < questions.Length)
        {
            currentQuestion = questions[currentQuestionNumber];
            questionDisplay.text = currentQuestion.questionText;
            resultDisplay.text = "";
        }
        else
        {
            endQuiz();
        }
    }

    void checkAnswer(int choice, question currentQuestion)
    {
        if (choice == currentQuestion.correctChoice)
        {
            correctAnswer();
        }
        else if (choice == -1)
        {
            skipQuestion();
        }
        else
        {
            incorrectAnswer();
        }
    }

    void correctAnswer()
    {
        score = score + 10;
        scoreDisplay.text = score.ToString();
        currentQuestionNumber++;
        Invoke("displayQuestion", 5.0f);
    }

    void incorrectAnswer()
    {
        score = score - 5;
        scoreDisplay.text = score.ToString();
        currentQuestionNumber++;
        Invoke("displayQuestion", 5.0f);
    }

    void skipQuestion()
    {
        currentQuestionNumber++;
        Invoke("displayQuestion", 5.0f);
    }

    void endQuiz()
    {

    }

    // Choice Buttons
    void choiceA()
    {
        checkAnswer(1, currentQuestion);
    }
    
    void choiceB()
    {
        checkAnswer(2, currentQuestion);
    }

    void choiceC()
    {
        checkAnswer(3, currentQuestion);
    }

    void choiceD()
    {
        checkAnswer(4, currentQuestion);
    }

    void skip()
    {
        checkAnswer(-1, currentQuestion);
    }
}
