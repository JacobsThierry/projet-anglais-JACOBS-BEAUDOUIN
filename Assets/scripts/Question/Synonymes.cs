using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synonymes
{
    public string mot;
    public List<List<string>> synonymes;

    public List<string> definitions;

    public Synonymes(string mot, List<List<string>> synonymes, List<string> definitions)
    {
        this.mot = mot;
        this.synonymes = synonymes;
        this.definitions = definitions;
    }

    public string getFirstDefinition(){
        return definitions[0];
    }

    public List<string> getAllSynonyms(){
        List<string> allSynonyms = new List<string>();
        foreach(List<string> list in synonymes){

            foreach(string elem in list){

                allSynonyms.Add(elem);
            }

        }
        return allSynonyms;
    }

}