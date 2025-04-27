using UnityEngine;

public class QuestionPackSelection {
    public static string[,] questionPacks = { 
        { "Questions.txt", "Choices.txt", "Answers.txt" },
    };

    public string[] GetQuestionPack() {
        int max = questionPacks.GetLength(0);
        int randomInt = Random.Range(0, max);
        string[] questionPack = new string[3];
        for (int i = 0; i < 3; i++) {
            questionPack[i] = questionPacks[randomInt, i];
        }
        return questionPack;
    }
}