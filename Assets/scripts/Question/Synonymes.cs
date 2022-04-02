using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synonymes
{
    public string mot;
    public JSONObject json;
    public Synonymes(string mot, JSONObject json)
    {
        this.mot = mot;
        this.json = json;
    }

    public string getFirstDefinition(){
        return json.definition[0];
    }

    public List<string> getAllSynonyms(){
        List<string> allSynonyms = new List<string>();
        foreach(List<string> list in json.synonyms){

            foreach(string elem in list){

                allSynonyms.Add(elem);
            }

        }
        return allSynonyms;
    }

}