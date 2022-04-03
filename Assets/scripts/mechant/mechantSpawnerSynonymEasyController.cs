using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantSpawnerSynonymEasyController : MonoBehaviour
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

    public Synonymes synonymeEasy = null;

    public GameObject mechantSynonymeEasy;


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


            mcht = SynonymesEasy();

            mcht.transform.position = transform.position + new Vector3(0, Random.Range(-spawnRange, spawnRange), 0);
        }

    }

    public GameObject SynonymesEasy()
    {
        if(synonymeEasy == null)
        {
            PauseGame();
            synonymeEasy = wordManager.getSynonymesEasy();
            Transform canvas = GameObject.Find("Canvas").transform;
            Instantiate(popup, canvas);
            popup.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = synonymeEasy.mot;

            string definition = "";
            for(int i= 0; i < synonymeEasy.json.definition.Count; i++)
            {
                definition +="Definition n°" + i.ToString() + "\n"+ synonymeEasy.json.definition[i] + "\n\n";
            }
            popup.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = definition;
            popup.SetActive(true);
            Debug.Log(synonymeEasy.mot);
        }

        GameObject mcht = Instantiate(mechantSynonymeEasy);
        mcht.GetComponent<MechantSynonymeEasyController>().NewStart(synonymeEasy);
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
