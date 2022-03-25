using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{


    void Awake()
    {

        GameObject[] list = FindObjectsOfType<GameObject>();
        bool b = false;
        foreach (GameObject gm in list)
        {
            if (gm.name == this.name && gm != this.gameObject)
            {
                Destroy(this.gameObject);
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
