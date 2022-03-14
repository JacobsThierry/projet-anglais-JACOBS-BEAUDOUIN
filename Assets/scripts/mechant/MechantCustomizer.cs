using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechantCustomizer : MonoBehaviour
{

    public float cosChance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, cosChance) > 0.5f)
        {
            gameObject.AddComponent(typeof(MechantMovementControllerCos));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
