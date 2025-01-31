using UnityEngine;
using UnityEngine.UI;

public class checkAnswer : MonoBehaviour
{
    public Text message;
    public string[] questions; // An array of the possible questions
    public string[][] answers; // 2D array of potential answers to each question 
    public int[] correctAnswers; // An array of the indexes of correct answers
    public float timer = 30;

    void start()
    {

    }

    void Update()
    {
        timer = timer - Time.deltaTime;   
    }

    void correctAnswer(int points)
    {
        message.text = "Correct answer. Well done";
        message.color = Color.green;
        incrementScore(points);
    }

    void noAnswer()
    {
        message.text = "No answer given.";
        message.color = Color.yellow;
    }

    void wrongAnswer()
    {
        message.text = "Wrong answer";
        message.color = Color.red;
    }

    static int incrementScore(int points)
    {
        points = points + 1;
        return points;
    }

    static int decrementScore(int points)
    {
        points = points - 1;
        return points;
    }
}
