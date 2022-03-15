using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverScoreDisplay : MonoBehaviour
{

    private TMPro.TextMeshProUGUI text;

    private void OnEnable()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "Score : " + scoreManager.score;
    }

}
