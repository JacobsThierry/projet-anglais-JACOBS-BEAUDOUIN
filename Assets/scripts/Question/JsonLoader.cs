using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Linq;

public class JsonLoader
{

    Dictionary<String, JSONObject> synonymes;

    public JsonLoader()
    {

        string text = File.ReadAllText("./Ressources/synonymes/synonymesCommon.json");
        synonymes = JsonConvert.DeserializeObject<Dictionary<String, JSONObject>>(text);
        Debug.Log(synonymes);

    }

    public string getRandomCommonWords()
    {

        System.Random random = new System.Random();
	    int index = random.Next(synonymes.Count);
        KeyValuePair<String, JSONObject> pair = synonymes.ElementAt(index);
        return pair.Key;
        // return synonymes["health"].synonyms[0][0];

    }

}




