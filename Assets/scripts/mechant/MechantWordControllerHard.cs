using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickPool;

public class MechantWordControllerHard : MechantWordController
{

    public GameObject popup;

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
        PauseGame();
        showPopup();
    }
    private void showPopup(){
        string def = wordManager.getDefHard(word);
        Transform canvas = GameObject.Find("Canvas").transform;
        GameObject popup2 = Instantiate(popup, canvas);
        popup2.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = this.word;
        popup2.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = def;
        popup2.SetActive(true);
        Debug.Log(this.word);
    }
}
