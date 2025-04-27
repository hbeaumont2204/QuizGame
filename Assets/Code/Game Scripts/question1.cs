using UnityEngine;

public class question1
{
    public string questionText; // The question
    public int correctChoice; // True or False

    // Constructor
    public question1(string questionText, int correctChoice)
    {
        this.questionText = questionText;
        this.correctChoice = correctChoice;
    }
}
