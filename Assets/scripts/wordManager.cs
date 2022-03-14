using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordManager
{

    private static string[] words = { "fuck", "shit", "poop" };


    public static string getWord()
    {
        return words[Random.Range(0, words.Length)];
    }


}
