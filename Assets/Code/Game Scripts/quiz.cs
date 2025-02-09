using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class quiz  : MonoBehaviour
{
    public question[] questions;
    public int currentQuestionNumber = 0;
    public int score = 0;
    int timer = 30;
    
    public Text questionDisplay;
    public Text scoreDisplay;
    public Text resultDisplay;

    private void Start()
    {
        setup();
    }

    void Update()
    {
        timer = timer - time.DeltaTime;
    }

    void setup()
    {

    }

    void displayQuestion()
    {
        if (currentQuestionNumber < questions.Length)
        {
            question currentQuestion = questions[currentQuestionNumber];
            questionDisplay.text = currentQuestion.questionText;
            resultDisplay.text = "";
        }
        else
        {
            endQuiz();
        }
    }

    void checkAnswer(int choice)
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
        await Task.Delay(5000);
        currentQuestionNumber++;
        displayQuestion();
    }

    void incorrectAnswer()
    {
        score = score - 5;
        scoreDisplay.text = score.ToString();
        await Task.Delay(5000);
        currentQuestionNumber++;
        displayQuestion();
    }

    void skipQuestion()
    {
        await Task.Delay(5000);
        currentQuestionNumber++;
        displayQuestion();
    }

    void endQuiz()
    {

    }

    void choiceA()
    {
        checkAnswer(1);
    }
    
    void choiceB()
    {
        checkAnswer(2);
    }

    void choiceC()
    {
        checkAnswer(3);
    }

    void choiceD()
    {
        checkAnswer(4);
    }

    void skip()
    {
        checkAnswer(-1);
    }
}
