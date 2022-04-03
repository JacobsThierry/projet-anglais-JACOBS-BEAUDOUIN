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

      text = GetComponent<TMPro.TextMeshProUGUI>();
      text.text = "Score : " + scoreManager.score;

      if (scoreManager.score >= 5)
      {
         text.text = "Score : " + scoreManager.score + " \n The hero is flying through the sky, trying to intercept the meteors before they hit the earth. He is typing the words as fast as possible, but some of the meteors are getting through.\n The hero is getting tired and the villain is laughing maniacally as the earth starts to shatter. \n Just then, a group of heroes arrives to help. With their combined effort, they are able to destroy all the remaining meteors and save the earth.";
      }

   }

}
