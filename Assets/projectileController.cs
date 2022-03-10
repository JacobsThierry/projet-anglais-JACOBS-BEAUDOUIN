using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    private TMPro.TextMeshPro textMeshPro;

    private char _character;

    public char character
    {
        get => _character;
        set
        {
            if (textMeshPro == null)
            {
                textMeshPro = GetComponent<TMPro.TextMeshPro>();
            }
            _character = value;
            textMeshPro.text = _character.ToString();

        }
    }

    public float projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TMPro.TextMeshPro>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(projectileSpeed, 0, 0);
    }

}
