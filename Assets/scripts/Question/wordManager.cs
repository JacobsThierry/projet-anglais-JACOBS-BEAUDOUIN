using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordManager
{

    private static JsonLoader jsonLoader = new JsonLoader();


    public wordManager(){

    }

    public wordManager(string str){

    }


    private static Question[] questions = {
        new Question("2 + 2 ?", "4"),
        new Question("Quelle est la capitale de la france ?", "Paris")
};

    public static string getWord()
    {
        string word = jsonLoader.getRandomCommonWords();
        return word;
    }

    public static Synonymes getSynonymes()
    {
        string word = jsonLoader.getRandomCommonWords();
        List<List<string>> synonymes = jsonLoader.getCommonSynonymesLists(word);
        List<string> definition = jsonLoader.getCommonDefinitionLists(word);
        Synonymes synonymes1 = new Synonymes(word,synonymes,definition);
        return synonymes1;
    }


    public static Question getQuestion()
    {
        return questions[Random.Range(0, questions.Length)];
    }


}
