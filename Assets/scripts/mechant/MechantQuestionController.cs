using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechantQuestionController : MechantWordController
{
    public string question;



    void Start()
    {

        Question q = wordManager.getQuestion();

        this.word = q.reponse;
        this.question = q.question;

        textMeshPro = GetComponent<TMPro.TextMeshPro>();

        updateGraphics();
    }



    protected override void updateGraphics()
    {
        Debug.Log("QuestionController update");

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

}
