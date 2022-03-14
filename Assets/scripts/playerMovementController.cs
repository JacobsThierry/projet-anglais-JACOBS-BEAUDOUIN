using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementController : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void FixedUpdate()
    {
        float vspeed = speed * Input.GetAxis("Vertical");
        float hspeed = speed * Input.GetAxis("Horizontal");

        this.transform.position += new Vector3(hspeed, vspeed, 0);
    }
}
