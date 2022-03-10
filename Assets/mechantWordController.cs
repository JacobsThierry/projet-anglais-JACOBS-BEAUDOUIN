using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantWordController : MonoBehaviour
{

    private TMPro.TextMeshPro textMeshPro;

    public string word;
    public int index
    {
        get => _index;

        set
        {
            _index = value;
            updateGraphics();
        }
    }


    private async void updateGraphics()
    {

        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TMPro.TextMeshPro>();
        }

        textMeshPro.richText = true;

        textMeshPro.text = "<color=red>";

        for (int i = 0; i < index; i++)
        {
            textMeshPro.text += word[i];
        }

        textMeshPro.text += "</color>";

        for (int i = index; i < word.Length; i++)
        {
            textMeshPro.text += word[i];
        }

    }


    private int _index = 0;

    // Start is called before the first frame update
    void Start()
    {
        word = wordManager.getWord();
        textMeshPro = GetComponent<TMPro.TextMeshPro>();

        updateGraphics();
    }



    public void hit(Collider2D other) //voir commentaire dans mechantMovementController dans ontriggerenter2D
    {
        GameObject go = other.gameObject;


        if (go.tag == "projectile")
        {


            projectileController pc = go.GetComponent<projectileController>();
            if (pc.character == word[index])
            {
                index++;

            }
            Destroy(go);
        }

        if (index == word.Length)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("riiip");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
