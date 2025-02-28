using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.IO;
using System;
using TMPro;

public class quiz  : MonoBehaviour
{
    public question[] questions = { }; // Array containing questions
    public int currentQuestionNumber = 0; // Index of the current question
    question currentQuestion; // The current question
    public int score = 10; // Player Score
    public bool questionActive;
    float timer = 30; // 30 seconds to answer every question
    // UI Display
    public TextMeshProUGUI questionDisplay;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI resultDisplay;
    public TextMeshProUGUI choiceA;
    public TextMeshProUGUI choiceB;
    public TextMeshProUGUI choiceC;
    public TextMeshProUGUI choiceD;
    public TextMeshProUGUI timerDisplay;
    [SerializeField] private Slider timerSlider;
    
    // Called at the start
    private void Start()
    {
        setup();
    }

    // Called every frame
    void Update()
    {
        if (timer > 0 && questionActive)
        {
            timer = timer - Time.deltaTime; // Timer 
            timerDisplay.text = (Convert.ToInt16(timer)).ToString();
            timerSlider.value = timer / 30;
            if (timer <= 15 && timer > 5)
            {
                timerDisplay.color = Color.yellow;
            }
            if (timer <= 5)
            {
                timerDisplay.color = Color.red;
            }
            
        }
        else if (timer <= 0 && questionActive)
        {
            Skip();
        }

    }

    // Takes questions, choices and the correct answer index from text files
    void setup()
    {
        string[] allQuestions = ReadFile("Assets/Files/Questions.txt");
        string[][] allChoices = GetChoices("Assets/Files/Choices.txt");
        string[] allAnswers =  ReadFile("Assets/Files/Answers.txt");
        // Adds every question to the array questions.
        for (int i = 0; i < allAnswers.Length; i++)
        {
            int answer = Convert.ToInt32(allAnswers[i]);
            question newQuestion = new question(allQuestions[i], allChoices[i], answer);
            Array.Resize(ref questions, questions.Length + 1);
            questions[questions.Length - 1] = newQuestion;
            //Debug.Log(allQuestions[i]);
            //Debug.Log(answer);
        }
        displayQuestion();
    }

    // Reads data from a text file
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
                    //Debug.Log(line);
                }
            }
        }
        else
        {
            Debug.Log("Error");
        }
        return data;
    }
    // Used to read the choices from a text file
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
                    //Debug.Log(line);
                }

            }
        }
        else
        {
            Debug.Log("Error");
        }
        return data;
    }
    // Displays the current question
    void displayQuestion()
    {
        if (currentQuestionNumber < questions.Length)
        {
            timer = 30;
            timerDisplay.color = Color.green;
            questionActive = true;
            currentQuestion = questions[currentQuestionNumber];
            questionDisplay.text = currentQuestion.questionText;
            resultDisplay.text = "";
            choiceA.text = currentQuestion.choices[0];
            choiceB.text = currentQuestion.choices[1];
            choiceC.text = currentQuestion.choices[2];
            choiceD.text = currentQuestion.choices[3];
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
        score = score + 10; // 10 points added for every correct answer
        scoreDisplay.text = score.ToString();
        if (score > 0)
        {
            scoreDisplay.color = Color.green;
        }
        resultDisplay.text = "Correct answer";
        resultDisplay.color = Color.green;
        currentQuestionNumber++;
        Invoke("displayQuestion", 5.0f); // Waits for 5 seconds before the next question
    }

    void incorrectAnswer()
    {
        score = score - 5; // 5 points lost for a correct answer
        scoreDisplay.text = score.ToString();
        if (score == 0)
        {
            scoreDisplay.color = Color.yellow;
        }
        else if (score < 0)
        {
            scoreDisplay.color = Color.red;
        }
        resultDisplay.text = "Incorrect answer";
        resultDisplay.color = Color.red;
        currentQuestionNumber++;
        Invoke("displayQuestion", 5.0f); // 5 second delay
    }

    void skipQuestion()
    {
        // No score change
        resultDisplay.text = "No answer given";
        resultDisplay.color = Color.yellow;
        currentQuestionNumber++;
        Invoke("displayQuestion", 5.0f); // 5 second delay
    }
    // Displays end score
    void endQuiz()
    {

    }

    // Choice Buttons
    public void ChoiceA()
    {
        if (questionActive)
        {
            questionActive = false;
            checkAnswer(1, currentQuestion);
        }
    }

    public void ChoiceB()
    {
        if (questionActive)
        {
            questionActive = false;
            checkAnswer(2, currentQuestion);
        }
        
    }

    public void ChoiceC()
    {
        if (questionActive)
        {
            questionActive = false;
            checkAnswer(3, currentQuestion);
        }  
    }

    public void ChoiceD()
    {
        if (questionActive)
        {
            questionActive = false;
            checkAnswer(4, currentQuestion);
        }
    }

    public void Skip()
    {
        if (questionActive)
        {
            questionActive = false;
            checkAnswer(-1, currentQuestion);
        }
    }
}
