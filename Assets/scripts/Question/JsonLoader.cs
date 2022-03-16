using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class JsonLoader{

    private SynonymesCommon synonymes = new SynonymesCommon();

    public JsonLoader(){
        
        string text = File.ReadAllText("./Ressources/synonymes/synonymesCommon.json");  
        synonymes.dico = JsonUtility.FromJson<Dictionary<string, Dictionary< string,List< List<string> > > >>(text);
        Debug.Log(synonymes.dico["after"]["definition"][0]);
        
    }

    public string getCommonWords(){
        return synonymes.getRandomWord();


    }

}




