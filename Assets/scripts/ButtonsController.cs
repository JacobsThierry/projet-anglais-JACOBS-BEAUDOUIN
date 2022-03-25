using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        asyncLoad = SceneManager.LoadSceneAsync("Game");
        asyncLoad.allowSceneActivation = false;
    }

    AsyncOperation asyncLoad;




    public void Jouer()
    {
        asyncLoad.allowSceneActivation = true;
    }
}
