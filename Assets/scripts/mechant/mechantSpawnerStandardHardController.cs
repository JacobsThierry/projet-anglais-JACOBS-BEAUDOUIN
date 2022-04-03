using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantSpawnerStandardHardController : MonoBehaviour
{
    public Transform canvas;
    public GameObject popup;

    public GameObject popUp;
    private static List<string> accents = new List<string>{"Irish", "Jamaica", "scot", "general", "Yorkshire", "rp", "us", "south"};

    private enum accent
            {
                Irish,
                Jamaica,
                Scottish,
                UK,
                UK_Yorkshire,
                UK_Standard,
                US,
                US_South

            }

    public GameObject mechantHard;

    public float timer;

    private float _timer;

    public float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        _timer = timer / 3; //On divise par 3 comme ça le premeir spawn est plus rapide
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _timer = timer;
            GameObject mcht;



            mcht = MechantHard();

            mcht.transform.position = transform.position + new Vector3(0, Random.Range(-spawnRange, spawnRange), 0);
        }

    }

    public GameObject MechantHard()
    {
        return Instantiate(mechantHard);
    }

}
