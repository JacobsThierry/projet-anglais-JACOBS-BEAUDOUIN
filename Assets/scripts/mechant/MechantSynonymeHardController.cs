using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MechantSynonymeHardController : MechantWordController
{


    void Start()
    {

        Synonymes synonymes = wordManager.getSynonymesHard();
        //Selection aléatoire
        List<List<String>> liste = synonymes.json.synonyms;
        int rand = UnityEngine.Random.Range(0, liste.Count);
        int rand2 = UnityEngine.Random.Range(0, liste[rand].Count);


        this.word = liste[rand][rand2];
        textMeshPro = GetComponent<TMPro.TextMeshPro>();

        updateGraphics();
    }



}
