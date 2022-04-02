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

    public static string getWordEasy()
    {
        string word = jsonLoader.getRandomCommonWords();
        return word;
    }

    public static string getWordHard(){
        string word = jsonLoader.getRandomHardWords();
        return word;
    }

    public static Synonymes getSynonymesEasy()
    {
        string word = jsonLoader.getRandomCommonWords();
        JSONObject json = jsonLoader.synonymes[word];
        Synonymes synonymes1 = new Synonymes(word,json);
        return synonymes1;
    }

    public static Synonymes getSynonymesHard()
    {
        string word = jsonLoader.getRandomHardWords();
        JSONObject json = jsonLoader.synonymes[word];
        Synonymes synonymes1 = new Synonymes(word,json);
        return synonymes1;
    }
    


    public static Question getQuestion()
    {
        return questions[Random.Range(0, questions.Length)];
    }

    public static string getWordForSynonyms(){ // easy mode or synonyms
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


    public static string getDefEasy(string word){
        string def ="";
        List<string> liste = jsonLoader.getCommonDefinitionLists(word);
        int longueur = liste.Count;
        for(int i = 0; i < longueur; i++){
            def += "Definition n°" + i.ToString() + " :\n";
            def += liste[i];
            def += "\n";
        }
        return def;
    }

    public static string getDefHard(string word){
        string def ="";
        List<string> liste = jsonLoader.getHardDefinitionLists(word);
        int longueur = liste.Count;
        for(int i = 0; i < longueur; i++){
            def += "Definition n°" + i.ToString() + " :\n";
            def += liste[i];
            def += "\n";
        }
        return def;
    }



}
