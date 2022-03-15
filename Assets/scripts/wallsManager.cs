using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickPool;

public class wallsManager : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "projectile")
        {
            other.gameObject.Despawn();
        }
    }

}
