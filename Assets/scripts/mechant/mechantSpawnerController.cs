using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantSpawnerController : MonoBehaviour
{

    public GameObject mechant;

    public GameObject mechantQuestion;

    public float timer;

    private float _timer;

    public float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        _timer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _timer = timer;
            GameObject mcht;


            if (Random.Range(0, 2) < 1)
            {
                mcht = Instantiate(mechantQuestion);
            }
            else
            {
                mcht = Instantiate(mechant);
            }




            mcht.transform.position = transform.position + new Vector3(0, Random.Range(-spawnRange, spawnRange), 0);
        }

    }
}
