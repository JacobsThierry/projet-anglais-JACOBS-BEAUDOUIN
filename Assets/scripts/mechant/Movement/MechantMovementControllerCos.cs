using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechantMovementControllerCos : MonoBehaviour
{

    private float timeAlive;

    public float amplitude = 0.05f;


    private void Start()
    {
        timeAlive = Random.Range(0, 6.3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeAlive += Time.deltaTime;
        transform.position -= new Vector3(0, Mathf.Cos(timeAlive), 0) * amplitude;
    }
}
