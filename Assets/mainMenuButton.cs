using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuButton : MonoBehaviour
{

   public void onClick()
   {

      foreach (GameObject go in UnityEngine.Object.FindObjectsOfType<GameObject>())
      {
         if (go.name.StartsWith("MechantSpawner"))
         {
            Destroy(go);
         }
      }

      SceneManager.LoadScene("MainMenu");
   }

}
