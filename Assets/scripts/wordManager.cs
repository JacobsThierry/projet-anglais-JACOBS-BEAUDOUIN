using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordManager
{

    private static string[] words = { "fuck", "shit", "poop" };


    private static Question[] questions = {
        new Question("2 + 2 ?", "4"),
        new Question("Quelle est la capitale de la france ?", "Paris")
};

    public static string getWord()
    {

        return words[Random.Range(0, words.Length)];
    }

    public static Question getQuestion()
    {
        return questions[Random.Range(0, questions.Length)];
    }


}
