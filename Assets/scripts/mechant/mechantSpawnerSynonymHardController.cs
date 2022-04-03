using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantSpawnerSynonymHardController : MonoBehaviour
{
    public Transform canvas;
    public GameObject popup;

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

    public Synonymes synonymeHard = null ;

    public GameObject mechantSynonymeHard;
   
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

            mcht = SynonymesHard();

            mcht.transform.position = transform.position + new Vector3(0, Random.Range(-spawnRange, spawnRange), 0);
        }

    }
    public GameObject SynonymesHard()
    {
        if(synonymeHard == null)
        {
            PauseGame();
            synonymeHard = wordManager.getSynonymesHard();
            Transform canvas = GameObject.Find("Canvas").transform;
            GameObject popup2 = Instantiate(popup, canvas);
            popup2.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = synonymeHard.mot;

            string definition = "";
            for(int i= 0; i < synonymeHard.json.definition.Count; i++)
            {
                definition +="Definition n°" + i.ToString() + "\n"+ synonymeHard.json.definition[i] + "\n\n";
            }
            popup2.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = definition;
            popup2.SetActive(true);
            Debug.Log(synonymeHard.mot);
        }
        GameObject mcht = Instantiate(mechantSynonymeHard);
        mcht.GetComponent<MechantSynonymeEasyController>().NewStart(synonymeHard);
        return mcht;
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
