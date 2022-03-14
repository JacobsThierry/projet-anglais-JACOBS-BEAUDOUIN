using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechantMovementControllerLinear : MonoBehaviour
{

    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }


}
