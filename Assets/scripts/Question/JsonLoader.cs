using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Linq;

public class JsonLoader
{

    public Dictionary<String, JSONObject> synonymes;

    public Dictionary<String, JSONObject> synonymesHard;

    public Dictionary<String, JSONAudio> audios;

    public JsonLoader()
    {

        string text = File.ReadAllText("./Assets/Resources/synonymes/synonymesCommon.json");
        synonymes = JsonConvert.DeserializeObject<Dictionary<String, JSONObject>>(text);

        string hard = File.ReadAllText("./Assets/Resources/synonymes/synonymes.json");
        synonymesHard = JsonConvert.DeserializeObject<Dictionary<String, JSONObject>>(hard);

        string text2 = File.ReadAllText("./Assets/Resources/audio/dicoWR.json");
        audios = JsonConvert.DeserializeObject<Dictionary<String, JSONAudio>>(text2);
    }

    public string getRandomCommonWords()
    {

        System.Random random = new System.Random();
	    int index = random.Next(synonymes.Count);
        KeyValuePair<String, JSONObject> pair = synonymes.ElementAt(index);
        return pair.Key;

    }

    public string getRandomHardWords(){
        System.Random random = new System.Random();
	    int index = random.Next(synonymesHard.Count);
        KeyValuePair<String, JSONObject> pair = synonymesHard.ElementAt(index);
        return pair.Key;
    }

    public List<string> getCommonDefinitionLists(string str){

        if(synonymes.ContainsKey(str)){
            return synonymes[str].definition;
        }
        else{
            return null;
        }

    }

    public List<string> getHardDefinitionLists(string str){
        if(synonymesHard.ContainsKey(str)){
            return synonymesHard[str].definition;
        }
        else{
            return null;
        }
    }

    public List<List<string>> getCommonSynonymesLists(string str){
        if(synonymes.ContainsKey(str)){
            return synonymes[str].synonyms;
        }
        else{
            return null;
        }

    }

    public string getRandomWordForAudio(string accent){
        String word = "";
        Boolean found = false;
        while(!found){
            System.Random random = new System.Random();
            int index = random.Next(audios.Count);
            KeyValuePair<String, JSONAudio> pair = audios.ElementAt(index);

            word = pair.Key;
            
            if(!(audios[word].getAccent(accent) == "")) // Si le mot est présent dans l'accent demandé
            {
                found = true;
            }
        }

        return word;
    }

    public string getAudioFromWord(string word, string accent){
        return audios[word].getAccent(accent);
    }

}




