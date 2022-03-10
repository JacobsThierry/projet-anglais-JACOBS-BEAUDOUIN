using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickPool;

public class playerKeyboard : MonoBehaviour
{
    public GameObject projectile;
    /*public float timer;

    private float _timer;
*/
    // Start is called before the first frame update
    void Start()
    {
        //resetTimer();
    }
    /*
        void resetTimer()
        {
            _timer = timer;
        }
    */


    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {



        //_timer -= _timer < 0 ? 0 : Time.deltaTime;

        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                ;
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                ;
            }
            else
            {
                /*if (_timer <= 0)
                {
                    resetTimer();
                    GameObject instance = projectile.Spawn(transform.position, Quaternion.identity);
                    projectileController pc = instance.GetComponent<projectileController>();
                    pc.character = c;

                }*/

                GameObject instance = projectile.Spawn(transform.position, Quaternion.identity);
                projectileController pc = instance.GetComponent<projectileController>();
                pc.character = c;



            }
        }


    }
}
