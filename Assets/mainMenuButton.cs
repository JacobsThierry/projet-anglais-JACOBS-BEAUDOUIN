using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuButton : MonoBehaviour
{

   public void onClick()
   {
      SceneManager.LoadScene("MainMenu");
   }

}
