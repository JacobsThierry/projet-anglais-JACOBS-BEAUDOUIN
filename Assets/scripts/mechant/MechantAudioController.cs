using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechantAudioController : MechantWordController
{

    public string question;

    private AudioClip audioClip;

    void Start()
    {
        this.question = "Sound (UK)";
        textMeshPro = GetComponent<TMPro.TextMeshPro>();
        updateGraphics();
    }

    public void NewStart(string accent){
        // Question q = wordManager.getQuestion();
        string word = wordManager.getWordForAudio(accent);
        this.word = word;

        string path = wordManager.getAudioFromWord(word, accent);
        //Load an AudioClip (Assets/Resources/Audio/audioClip01.mp3)
        this.audioClip = Resources.Load<AudioClip>(path);
 
        OnMouseDown();
        updateGraphics();
    }



    protected override void updateGraphics()
    {
        Debug.Log("AudioController update");

        getTextMeshPro();

        textMeshPro.richText = true;

        textMeshPro.text = "<color=black>";

        textMeshPro.text += question + '\n';

        textMeshPro.text += "</color>";

        textMeshPro.text += "<color=red>";

        for (int i = 0; i < index; i++)
        {
            textMeshPro.text += word[i];
        }

        textMeshPro.text += "</color>";
        
        textMeshPro.text += "<color=black>";

        for (int i = index; i < word.Length; i++)
        {
            textMeshPro.text += "_ ";
        }

         textMeshPro.text += "</color>";

    }

    public void OnMouseDown(){
        SoundManager.instance.playSound(audioClip);
    }

}
