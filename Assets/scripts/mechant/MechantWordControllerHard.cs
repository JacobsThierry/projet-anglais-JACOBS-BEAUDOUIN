using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickPool;

public class MechantWordControllerHard : MechantWordController
{

    private bool gameIsPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        word = wordManager.getWordHard();
        textMeshPro = GetComponent<TMPro.TextMeshPro>();

        updateGraphics();
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    public void OnMouseDown(){
        if(gameIsPaused){
            gameIsPaused = false;
            updateGraphics();
            ResumeGame();
        }
        else{
            gameIsPaused = true;
            string def = wordManager.getDefHard(word);
            textMeshPro.richText = true;
            def += "<color=black>";
            textMeshPro.text = def;
            def += "</color>";
            PauseGame();
        }
    }
}
