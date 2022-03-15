using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{

    public static TMPro.TextMeshProUGUI instance;
    public static int score
    {
        get => _score;
        set
        {
            _score = value;
            updateTexte();
        }
    }

    private static int _score;

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<TMPro.TextMeshProUGUI>();
        score = 0;
    }

    private static void updateTexte()
    {
        instance.text = "Score : " + score.ToString();
    }
}
