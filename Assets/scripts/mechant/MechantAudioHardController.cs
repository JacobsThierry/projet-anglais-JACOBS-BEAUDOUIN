using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechantAudioHardController : MechantWordController
{

    private static List<string> accents = new List<string>{"Irish", "Jamaica", "scot", "general", "Yorkshire", "rp", "us", "south"};

    private static List<string> accents_name = new List<string>{"Irish", "Jamaica", "Scottish", "UK", "Yorkshire", "UK", "US", "South"};
        private enum accent
                {
                    Irish,
                    Jamaica,
                    Scottish,
                    UK,
                    UK_Yorkshire,
                    UK_Standard,
                    US,
                    US_South

                }
    public string question;

    private AudioClip audioClip;

    void Start()
    {
        // this.question = "Sound";
        textMeshPro = GetComponent<TMPro.TextMeshPro>();
        updateGraphics();
    }

    public void NewStart(string word){
        // Question q = wordManager.getQuestion();

        this.word = word;

        string path = "";
        int rand = 3;
        while(path == ""){
            // get a random word between 0 and the number of words in the list
            rand = UnityEngine.Random.Range(0, accents.Count);
            path = wordManager.getAudioFromWord(word, accents[rand]);
        }
        //Load an AudioClip (Assets/Resources/Audio/audioClip01.mp3)
        this.audioClip = Resources.Load<AudioClip>(path);
        this.question = "(" + accents_name[rand] + ")";
 
        OnMouseDown();
        updateGraphics();
    }



    protected override void updateGraphics()
    {
        Debug.Log("AudioController update");

        getTextMeshPro();

        textMeshPro.richText = true;

        textMeshPro.text = question + '\n';

        textMeshPro.text += "<color=red>";

        for (int i = 0; i < index; i++)
        {
            textMeshPro.text += word[i];
        }

        textMeshPro.text += "</color>";


        for (int i = index; i < word.Length; i++)
        {
            textMeshPro.text += "_ ";
        }

    }

    public void OnMouseDown(){
        SoundManager.instance.playSound(audioClip);
    }

}
