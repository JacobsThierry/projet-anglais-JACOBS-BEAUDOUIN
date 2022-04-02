using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordManager
{

    private static JsonLoader jsonLoader = new JsonLoader();

    private static List<string> accents = new List<string>{"Irish", "Jamaica", "scot", "general", "Yorkshire", "rp", "us", "south"};


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
        // string word = jsonLoader.getRandomCommonWords();
        // test
        string word = jsonLoader.getRandomWordForAudio(accents[0]);
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

    public static string getWordForSynonyms(){
        string word = jsonLoader.getRandomCommonWords();
        return word;
    }

    public static string getWordForAudio(string accent){
        string word = jsonLoader.getRandomWordForAudio(accent);
        return word;
    }

    public static string getAudioFromWord(string word, string accent){
        string audio = jsonLoader.getAudioFromWord(word, accent);
        return audio;
    }



}
