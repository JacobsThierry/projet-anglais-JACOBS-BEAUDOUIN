using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantMovementController : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }


}
