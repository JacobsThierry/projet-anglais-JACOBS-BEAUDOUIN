using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickPool;

public class MechantWordController : MonoBehaviour
{



    protected TMPro.TextMeshPro textMeshPro;

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


    protected void getTextMeshPro()
    {
        if (textMeshPro == null)
        {
            textMeshPro = transform.GetChild(0).GetComponent<TMPro.TextMeshPro>();
        }
    }


    protected virtual void updateGraphics()
    {

        Debug.Log("WordController update");

        getTextMeshPro();

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


    private void OnTriggerEnter2D(Collider2D other)
    {
        hit(other);
    }


    public void hit(Collider2D other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "projectile")
        {
            projectileController pc = go.GetComponent<projectileController>();
            if (char.ToLower(pc.character) == char.ToLower(word[index]))
            {
                index++;

            }
            go.Despawn();

            if (index == word.Length)
            {
                Destroy(this.gameObject);
            }

            updateGraphics();
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
